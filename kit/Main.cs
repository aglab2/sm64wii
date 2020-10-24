using System;
using System.Diagnostics;
using System.IO;
using static System.Net.IPAddress;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Security;
using System.Globalization;

namespace sm64wiikit
{
    public partial class Main : Form
    {
        const int ControllerConfigStart = 0x1685C8;
        const int ControllerConfigOffset = 0x50;

        enum Status
        {
            READY,
            LOADING,
            PREPARING,
        };

        readonly string tempFolder;
        Process runningProcess;
        string fileName;
        MethodInvoker onProcessExit;

        private void SafeInvoke(MethodInvoker updater, bool forceSynchronous = false)
        {
            if (InvokeRequired)
            {
                if (forceSynchronous)
                {
                    Invoke((MethodInvoker)delegate { SafeInvoke(updater, forceSynchronous); });
                }
                else
                {
                    BeginInvoke((MethodInvoker)delegate { SafeInvoke(updater, forceSynchronous); });
                }
            }
            else
            {
                if (IsDisposed)
                {
                    throw new ObjectDisposedException("Control is already disposed.");
                }

                updater();
            }
        }

        static string GetTemporaryDirectory()
        {
            string tempFolder = Path.GetTempFileName();
            File.Delete(tempFolder);
            Directory.CreateDirectory(tempFolder);

            return tempFolder;
        }

        private void SetStatus(Status s)
        {
            string statusText = "";
            switch (s)
            {
                case Status.READY:
                    statusText = "Ready";
                    break;
                case Status.LOADING:
                    statusText = "Loading...";
                    break;
                case Status.PREPARING:
                    statusText = "Preparing";
                    break;
            }
            labelStatus.Text = statusText;

            if (s == Status.READY)
            {
                buttonOpen.Enabled = true;
                buttonInject.Enabled = true;
                buttonSave.Enabled = true;
            }
            else
            {
                buttonOpen.Enabled = false;
                buttonInject.Enabled = false;
                buttonSave.Enabled = false;
            }
        }

        public Main()
        {
            InitializeComponent();

            FormClosed += Main_FormClosed;
            tempFolder = GetTemporaryDirectory();
            SetStatus(Status.PREPARING);
            Prepare();
        }

        private void Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            Directory.Delete(tempFolder, true);
        }

        private void ExecuteGzInject(string args, bool redirectStdIn = false)
        {
            var gzinjectPath = Path.Combine(tempFolder, "gzinject.exe");
            runningProcess = new Process();
            {
                runningProcess.StartInfo.FileName = gzinjectPath;
                runningProcess.StartInfo.Arguments = args;
                runningProcess.StartInfo.WorkingDirectory = tempFolder;
                runningProcess.StartInfo.ErrorDialog = true;
                runningProcess.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                runningProcess.StartInfo.RedirectStandardInput = redirectStdIn;
                runningProcess.StartInfo.UseShellExecute = false;
                runningProcess.Start();
                runningProcess.EnableRaisingEvents = true;
                runningProcess.Exited += Process_Exited;
            }
        }

        double toSlope(double diag, double max)
        {
            return (max - diag) / diag;
        }

        double toDiag(double slope, double max)
        {
            return max / (1 + slope);
        }

        private void Prepare()
        {
            var gzinjectPath = Path.Combine(tempFolder, "gzinject.exe");
            File.WriteAllBytes(gzinjectPath, Resources.gzinject);

            ExecuteGzInject("-a genkey", true);

            using (var sw = runningProcess.StandardInput)
            {
                sw.WriteLine("45e");
                sw.Close();
            }
        }

        [DllImport("ntdll"), SuppressUnmanagedCodeSecurity]
        public static extern int RtlFindLeastSignificantBit(ulong ul);


        private int ToIndex(UInt16 button)
        {
            if (0 == button)
                return 0;

            var lsb = RtlFindLeastSignificantBit((ulong) button);
            var mask = 1 << lsb;
            if (mask == button)
                return 16 - lsb;

            return 17; // custom
        }

        private void ParseEmu()
        {
            var emuPath = Path.Combine(tempFolder, "wadextract", "content1.app");
            var emuData = File.ReadAllBytes(emuPath);

            checkBoxCrashesFix.Checked      = emuData[0xB7FDC] == 0x48;
            checkBoxShadeRemove.Checked     = emuData[0x16B0B3] == 0xff;
            checkBoxControlStickFix.Checked = emuData[0x102b] == 0x98 || emuData[0x102b] == 0x88;
            checkBoxFramewalk.Checked       = emuData[0x102b] == 0x88 || emuData[0x102b] == 0xf8;
            checkBoxExtendedRAM.Checked     = emuData[0x5AD4] == 0x60;

            SetupControlStickMappingControls();

            if (checkBoxControlStickFix.Checked)
            {
                var i1 = HostToNetworkOrder(BitConverter.ToInt64(emuData, 0x1000));
                var i2 = HostToNetworkOrder(BitConverter.ToInt64(emuData, 0x1008));
                var i3 = HostToNetworkOrder(BitConverter.ToInt64(emuData, 0x1010));
                var i4 = HostToNetworkOrder(BitConverter.ToInt64(emuData, 0x1018));
                var gcMax = BitConverter.Int64BitsToDouble(i1);
                var gcSlope = BitConverter.Int64BitsToDouble(i2);
                var n64Max = BitConverter.Int64BitsToDouble(i3);
                var n64Slope = BitConverter.Int64BitsToDouble(i4);
                var gcDiag = gcSlope > 1 ? gcSlope : toDiag(gcSlope, gcMax);
                var n64Diag = n64Slope > 1 ? n64Slope : toDiag(n64Slope, n64Max); 
                textBoxGCMax.Text = ((int) gcMax).ToString();
                textBoxGCDiag.Text = ((int) gcDiag).ToString();
                textBoxN64Max.Text = ((int) n64Max).ToString();
                textBoxN64Diag.Text = ((int) n64Diag).ToString();
            }

            {
                var b1 = emuData[0x5C176];
                var b2 = emuData[0x5C177];
                int romSize = (b1 & 0xf) << 4 | ((b2 >> 4) & 0xf);
                textBoxROMSize.Text = romSize.ToString("X");
            }

            {
                var buttonA = (UInt16)NetworkToHostOrder(BitConverter.ToInt16(emuData, ControllerConfigStart + ControllerConfigOffset + 0x0));
                var buttonB = (UInt16)NetworkToHostOrder(BitConverter.ToInt16(emuData, ControllerConfigStart + ControllerConfigOffset + 0x4));
                var buttonX = (UInt16)NetworkToHostOrder(BitConverter.ToInt16(emuData, ControllerConfigStart + ControllerConfigOffset + 0x8));
                var buttonY = (UInt16)NetworkToHostOrder(BitConverter.ToInt16(emuData, ControllerConfigStart + ControllerConfigOffset + 0xC));
                var buttonL = (UInt16)NetworkToHostOrder(BitConverter.ToInt16(emuData, ControllerConfigStart + ControllerConfigOffset + 0x10));
                var buttonR = (UInt16)NetworkToHostOrder(BitConverter.ToInt16(emuData, ControllerConfigStart + ControllerConfigOffset + 0x14));
                var buttonZ = (UInt16)NetworkToHostOrder(BitConverter.ToInt16(emuData, ControllerConfigStart + ControllerConfigOffset + 0x18));
                var buttonS = (UInt16)NetworkToHostOrder(BitConverter.ToInt16(emuData, ControllerConfigStart + ControllerConfigOffset + 0x1c));
                // dpad?
                var buttonCU = (UInt16)NetworkToHostOrder(BitConverter.ToInt16(emuData, ControllerConfigStart + ControllerConfigOffset + 0x40));
                var buttonCD = (UInt16)NetworkToHostOrder(BitConverter.ToInt16(emuData, ControllerConfigStart + ControllerConfigOffset + 0x44));
                var buttonCL = (UInt16)NetworkToHostOrder(BitConverter.ToInt16(emuData, ControllerConfigStart + ControllerConfigOffset + 0x48));
                var buttonCR = (UInt16)NetworkToHostOrder(BitConverter.ToInt16(emuData, ControllerConfigStart + ControllerConfigOffset + 0x4c));

                textBoxA.Text = buttonA.ToString("X4");
                textBoxB.Text = buttonB.ToString("X4");
                textBoxX.Text = buttonX.ToString("X4");
                textBoxY.Text = buttonY.ToString("X4");
                textBoxL.Text = buttonL.ToString("X4");
                textBoxR.Text = buttonR.ToString("X4");
                textBoxZ.Text = buttonZ.ToString("X4");
                textBoxS.Text = buttonS.ToString("X4");
                // dpad
                textBoxCU.Text = buttonCU.ToString("X4");
                textBoxCD.Text = buttonCD.ToString("X4");
                textBoxCL.Text = buttonCL.ToString("X4");
                textBoxCR.Text = buttonCR.ToString("X4");

                comboBoxA.SelectedIndex = ToIndex(buttonA);
                comboBoxB.SelectedIndex = ToIndex(buttonB);
                comboBoxX.SelectedIndex = ToIndex(buttonX);
                comboBoxY.SelectedIndex = ToIndex(buttonY);
                comboBoxL.SelectedIndex = ToIndex(buttonL);
                comboBoxR.SelectedIndex = ToIndex(buttonR);
                comboBoxZ.SelectedIndex = ToIndex(buttonZ);
                comboBoxS.SelectedIndex = ToIndex(buttonS);
                // dpad
                comboBoxCU.SelectedIndex = ToIndex(buttonCU);
                comboBoxCD.SelectedIndex = ToIndex(buttonCD);
                comboBoxCL.SelectedIndex = ToIndex(buttonCL);
                comboBoxCR.SelectedIndex = ToIndex(buttonCR);
            }
        }

        private void Process_Exited(object sender, EventArgs e)
        {
            var exitCode = 0;
            if (runningProcess is object)
            {
                exitCode = runningProcess.ExitCode;
                runningProcess.Dispose();
                runningProcess = null;
            }

            SafeInvoke(delegate
            {
                if (0 != exitCode)
                {
                    MessageBox.Show($"Failed to perform action!", "gzinject", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (onProcessExit is object)
                    {
                        onProcessExit();
                    }
                }
                SetStatus(Status.READY);
            });
        }

        private void buttonOpen_Click(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog()
            {
                Title = "Load WAD file",
                Filter = "WAD files (*.wad)|*.wad"
            };

            if (DialogResult.OK == ofd.ShowDialog())
            {
                SetStatus(Status.LOADING);
                var filePath = ofd.FileName;
                fileName = Path.GetFileName(filePath);

                onProcessExit = delegate
                {
                    ParseEmu();
                    MessageBox.Show($"Opened file {filePath} successfully!", "gzinject", MessageBoxButtons.OK, MessageBoxIcon.Information);
                };
                ExecuteGzInject($"-a extract -w \"{filePath}\"");
            }
        }
        public void ToBytes(Int64 g, byte[] output, int outputOffset)
        {
            unsafe
            {
                fixed (byte* b = &output[outputOffset])
                {
                    IntPtr p = new IntPtr(b);
                    Marshal.StructureToPtr(g, p, false);
                }
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (!(fileName is object))
            {
                MessageBox.Show("WAD is not loaded! Use 'Open' button", "Save Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var sfd = new SaveFileDialog()
            {
                FileName = $"{Path.GetFileNameWithoutExtension(fileName)}-patch{Path.GetExtension(fileName)}",
                Filter = "WAD files (*.wad)|*.wad",
                Title = "Save WAD file"
            };
            if (DialogResult.OK == sfd.ShowDialog())
            {
                SetStatus(Status.LOADING);

                var emuPath = Path.Combine(tempFolder, "wadextract", "content1.app");
                var emuData = File.ReadAllBytes(emuPath);
                {
                    var n64Max = double.Parse(textBoxN64Max.Text);
                    var n64Diag = double.Parse(textBoxN64Diag.Text);
                    var gcMax = double.Parse(textBoxGCMax.Text);
                    var gcDiag = double.Parse(textBoxGCDiag.Text);

                    var n64Slope = toSlope(n64Diag, n64Max);
                    var gcSlope = toSlope(gcDiag, gcMax);

                    var i1 = NetworkToHostOrder(BitConverter.DoubleToInt64Bits(gcMax));
                    var i2 = NetworkToHostOrder(BitConverter.DoubleToInt64Bits(gcSlope));
                    var i3 = NetworkToHostOrder(BitConverter.DoubleToInt64Bits(n64Max));
                    var i4 = NetworkToHostOrder(BitConverter.DoubleToInt64Bits(n64Slope));
                    ToBytes(i1, emuData, 0x1000);
                    ToBytes(i2, emuData, 0x1008);
                    ToBytes(i3, emuData, 0x1010);
                    ToBytes(i4, emuData, 0x1018);
                }
                {
                    var buttonA = short.Parse(textBoxA.Text, NumberStyles.HexNumber);
                    var buttonB = short.Parse(textBoxB.Text, NumberStyles.HexNumber);
                    var buttonX = short.Parse(textBoxX.Text, NumberStyles.HexNumber);
                    var buttonY = short.Parse(textBoxY.Text, NumberStyles.HexNumber);
                    var buttonL = short.Parse(textBoxL.Text, NumberStyles.HexNumber);
                    var buttonR = short.Parse(textBoxR.Text, NumberStyles.HexNumber);
                    var buttonZ = short.Parse(textBoxZ.Text, NumberStyles.HexNumber);
                    var buttonS = short.Parse(textBoxS.Text, NumberStyles.HexNumber);
                    var buttonCU = short.Parse(textBoxCU.Text, NumberStyles.HexNumber);
                    var buttonCD = short.Parse(textBoxCD.Text, NumberStyles.HexNumber);
                    var buttonCL = short.Parse(textBoxCL.Text, NumberStyles.HexNumber);
                    var buttonCR = short.Parse(textBoxCR.Text, NumberStyles.HexNumber);

                    for (int i = 0; i < 3; i++)
                    {
                        var off = i * ControllerConfigOffset;
                        ToBytes(NetworkToHostOrder(buttonA), emuData, ControllerConfigStart + off + 0x0);
                        ToBytes(NetworkToHostOrder(buttonB), emuData, ControllerConfigStart + off + 0x4);
                        ToBytes(NetworkToHostOrder(buttonX), emuData, ControllerConfigStart + off + 0x8);
                        ToBytes(NetworkToHostOrder(buttonY), emuData, ControllerConfigStart + off + 0xC);
                        ToBytes(NetworkToHostOrder(buttonL), emuData, ControllerConfigStart + off + 0x10);
                        ToBytes(NetworkToHostOrder(buttonR), emuData, ControllerConfigStart + off + 0x14);
                        ToBytes(NetworkToHostOrder(buttonZ), emuData, ControllerConfigStart + off + 0x18);
                        ToBytes(NetworkToHostOrder(buttonS), emuData, ControllerConfigStart + off + 0x1c);
                        // dpad?
                        ToBytes(NetworkToHostOrder(buttonCU), emuData, ControllerConfigStart + off + 0x40);
                        ToBytes(NetworkToHostOrder(buttonCD), emuData, ControllerConfigStart + off + 0x44);
                        ToBytes(NetworkToHostOrder(buttonCL), emuData, ControllerConfigStart + off + 0x48);
                        ToBytes(NetworkToHostOrder(buttonCR), emuData, ControllerConfigStart + off + 0x4c);
                    }
                }
                File.WriteAllBytes(emuPath, emuData);

                var filePath = sfd.FileName;
                var patchPath = Path.Combine(tempFolder, "patch.gzi");
                string patchLines = "0000 00000000 00000001\n";
                if (checkBoxCrashesFix.Checked)
                {
                    patchLines += Resources.crashes_fix_on;
                }
                else
                {
                    patchLines += Resources.crashes_fix_off;
                }
                patchLines += "\n";

                if (checkBoxShadeRemove.Checked)
                {
                    patchLines += Resources.vc_shaded_picture_fix_on;
                }
                else
                {
                    patchLines += Resources.vc_shaded_picture_fix_off;
                }
                patchLines += "\n";

                if (checkBoxFramewalk.Checked && checkBoxControlStickFix.Checked)
                {
                    patchLines += Resources.framewalk_stick_mapping_on;
                }
                if (checkBoxFramewalk.Checked && !checkBoxControlStickFix.Checked)
                {
                    patchLines += Resources.framewalk_stick_mapping_off;
                }
                if (!checkBoxFramewalk.Checked && checkBoxControlStickFix.Checked)
                {
                    patchLines += Resources.control_stick_mapping_on;
                }
                if (!checkBoxFramewalk.Checked && !checkBoxControlStickFix.Checked)
                {
                    patchLines += Resources.control_stick_mapping_off;
                }
                patchLines += "\n";

                if (checkBoxExtendedRAM.Checked)
                {
                    patchLines += Resources.extended_ram_on;
                }
                else
                {
                    patchLines += Resources.extended_ram_off;
                }
                patchLines += "\n";

                {
                    string romSize = textBoxROMSize.Text;
                    if (romSize.Length == 1)
                        romSize = "0" + romSize;

                    patchLines += string.Format(Resources.rom_size_tmpl, textBoxROMSize.Text);
                }
                patchLines += "\n";
                File.WriteAllText(patchPath, patchLines);

                onProcessExit = delegate
                {
                    MessageBox.Show($"Saved file {filePath} successfully!", "gzinject", MessageBoxButtons.OK, MessageBoxIcon.Information);
                };
                ExecuteGzInject($"-a pack -w \"{filePath}\" -p \"{patchPath}\"");
            }
        }

        private void SetupControlStickMappingControls()
        {
            if (checkBoxControlStickFix.Checked)
            {
                textBoxGCMax.Enabled = true;
                textBoxN64Max.Enabled = true;
                if (!checkBoxLockDiag.Checked)
                {
                    textBoxGCDiag.Enabled = true;
                    textBoxN64Diag.Enabled = true;
                }
                else
                {
                    textBoxGCDiag.Enabled = false;
                    textBoxN64Diag.Enabled = false;
                }
            }
            else
            {
                textBoxGCMax.Enabled = false;
                textBoxGCDiag.Enabled = false;
                textBoxN64Max.Enabled = false;
                textBoxN64Diag.Enabled = false;
            }
        }

        private void checkBoxControlStickFix_CheckedChanged(object sender, EventArgs e)
        {
            SetupControlStickMappingControls();
        }

        private void checkBoxLockDiag_CheckedChanged(object sender, EventArgs e)
        {
            SetupControlStickMappingControls();
        }

        private void buttonLoadMappingDefaults_Click(object sender, EventArgs e)
        {
            textBoxGCMax.Text = "106";
            textBoxGCDiag.Text = "75";
            textBoxN64Max.Text = "80";
            textBoxN64Diag.Text = "70";
        }

        private void textBoxGCMax_TextChanged(object sender, EventArgs e)
        {
            if (!checkBoxLockDiag.Checked)
            {
                return;
            }

            double val;
            if (double.TryParse(textBoxGCMax.Text, out val))
            {
                double d = val * Math.Sqrt(0.5);
                textBoxGCDiag.Text = d.ToString();
            }
        }

        private void textBoxN64Max_TextChanged(object sender, EventArgs e)
        {
            if (!checkBoxLockDiag.Checked)
            {
                return;
            }

            double val;
            if (double.TryParse(textBoxN64Max.Text, out val))
            {
                textBoxN64Diag.Text = (val * 7f / 8f).ToString();
            }
        }

        private void comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = null;
            TextBox textBox = null;
            if (sender == comboBoxA)
            {
                comboBox = comboBoxA;
                textBox = textBoxA;
            }
            if (sender == comboBoxB)
            {
                comboBox = comboBoxB;
                textBox = textBoxB;
            }
            if (sender == comboBoxX)
            {
                comboBox = comboBoxX;
                textBox = textBoxX;
            }
            if (sender == comboBoxY)
            {
                comboBox = comboBoxY;
                textBox = textBoxY;
            }
            if (sender == comboBoxS)
            {
                comboBox = comboBoxS;
                textBox = textBoxS;
            }
            if (sender == comboBoxL)
            {
                comboBox = comboBoxL;
                textBox = textBoxL;
            }
            if (sender == comboBoxR)
            {
                comboBox = comboBoxR;
                textBox = textBoxR;
            }
            if (sender == comboBoxZ)
            {
                comboBox = comboBoxZ;
                textBox = textBoxZ;
            }
            if (sender == comboBoxCU)
            {
                comboBox = comboBoxCU;
                textBox = textBoxCU;
            }
            if (sender == comboBoxCD)
            {
                comboBox = comboBoxCD;
                textBox = textBoxCD;
            }
            if (sender == comboBoxCL)
            {
                comboBox = comboBoxCL;
                textBox = textBoxCL;
            }
            if (sender == comboBoxCR)
            {
                comboBox = comboBoxCR;
                textBox = textBoxCR;
            }

            var idx = comboBox.SelectedIndex;
            string txt = null;
            if (0 == idx)
            {
                txt = "0000";
            }
            else if (idx >= 17)
            {
                return;
            }
            else
            {
                var mask = 1 << (16 - idx);
                txt = mask.ToString("X4");
            }

            if (txt is object && txt != textBox.Text && 4 == textBox.Text.Length)
            {
                textBox.Text = txt;
            }
        }

        private void textBoxA_TextChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = null;
            TextBox textBox = null;
            if (sender == textBoxA)
            {
                comboBox = comboBoxA;
                textBox = textBoxA;
            }
            if (sender == textBoxB)
            {
                comboBox = comboBoxB;
                textBox = textBoxB;
            }
            if (sender == textBoxX)
            {
                comboBox = comboBoxX;
                textBox = textBoxX;
            }
            if (sender == textBoxY)
            {
                comboBox = comboBoxY;
                textBox = textBoxY;
            }
            if (sender == textBoxS)
            {
                comboBox = comboBoxS;
                textBox = textBoxS;
            }
            if (sender == textBoxL)
            {
                comboBox = comboBoxL;
                textBox = textBoxL;
            }
            if (sender == textBoxR)
            {
                comboBox = comboBoxR;
                textBox = textBoxR;
            }
            if (sender == textBoxZ)
            {
                comboBox = comboBoxZ;
                textBox = textBoxZ;
            }
            if (sender == textBoxCU)
            {
                comboBox = comboBoxCU;
                textBox = textBoxCU;
            }
            if (sender == textBoxCD)
            {
                comboBox = comboBoxCD;
                textBox = textBoxCD;
            }
            if (sender == textBoxCL)
            {
                comboBox = comboBoxCL;
                textBox = textBoxCL;
            }
            if (sender == textBoxCR)
            {
                comboBox = comboBoxCR;
                textBox = textBoxCR;
            }

            if (!UInt16.TryParse(textBox.Text, NumberStyles.HexNumber, CultureInfo.InvariantCulture, out UInt16 val))
                return;

            var idx = ToIndex(val);
            if (idx != comboBox.SelectedIndex)
                comboBox.SelectedIndex = idx;
        }

        private void buttonInject_Click(object sender, EventArgs e)
        {
            if (!(fileName is object))
            {
                MessageBox.Show("WAD is not loaded! Use 'Open' button", "Inject Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var ofd = new OpenFileDialog()
            {
                Title = "Load ROM file",
                Filter = "Z64 files (*.z64)|*.z64"
            };

            if (DialogResult.OK == ofd.ShowDialog())
            {
                var filePath = ofd.FileName;
                var romPath = Path.Combine(tempFolder, "wadextract", "content5", "rom");
                File.Delete(romPath);
                File.Copy(filePath, romPath);
                var romSize = new FileInfo(romPath).Length;
                var romLoadSizeMb = 1 + romSize / 1024 / 1024;
                textBoxROMSize.Text = romLoadSizeMb.ToString("X2");
                const int MaxRomLoadSizeMb = 56;
                if (romLoadSizeMb > MaxRomLoadSizeMb)
                {
                    MessageBox.Show($"ROM injected successfully! Your ROM required {romLoadSizeMb}MB but VC can handle most {MaxRomLoadSizeMb}MBs! Considering using sm64compress or ROMManagerCompress", "Inject", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("ROM injected successfully!", "Inject", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                checkBoxCrashesFix.Checked = true;
                checkBoxShadeRemove.Checked = true;
                checkBoxExtendedRAM.Checked = true;
                checkBoxControlStickFix.Checked = true;
            }
        }
    }
}
