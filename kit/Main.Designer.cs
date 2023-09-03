using System.IO;

namespace sm64wiikit
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonOpen = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.checkBoxControlStickFix = new System.Windows.Forms.CheckBox();
            this.textBoxROMSize = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.checkBoxShadeRemove = new System.Windows.Forms.CheckBox();
            this.checkBoxCrashesFix = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkBoxExtendedRAM = new System.Windows.Forms.CheckBox();
            this.labelStatus = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.buttonLoadMappingDefaults = new System.Windows.Forms.Button();
            this.checkBoxLockDiag = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.labelMax = new System.Windows.Forms.Label();
            this.textBoxN64Diag = new System.Windows.Forms.TextBox();
            this.textBoxGCDiag = new System.Windows.Forms.TextBox();
            this.textBoxN64Max = new System.Windows.Forms.TextBox();
            this.textBoxGCMax = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.checkBoxFramewalk = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.textBoxCR = new System.Windows.Forms.TextBox();
            this.textBoxCL = new System.Windows.Forms.TextBox();
            this.textBoxCD = new System.Windows.Forms.TextBox();
            this.textBoxCU = new System.Windows.Forms.TextBox();
            this.textBoxS = new System.Windows.Forms.TextBox();
            this.textBoxZ = new System.Windows.Forms.TextBox();
            this.textBoxR = new System.Windows.Forms.TextBox();
            this.textBoxL = new System.Windows.Forms.TextBox();
            this.textBoxY = new System.Windows.Forms.TextBox();
            this.textBoxX = new System.Windows.Forms.TextBox();
            this.textBoxB = new System.Windows.Forms.TextBox();
            this.textBoxA = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.comboBoxCR = new System.Windows.Forms.ComboBox();
            this.comboBoxCL = new System.Windows.Forms.ComboBox();
            this.comboBoxCD = new System.Windows.Forms.ComboBox();
            this.comboBoxCU = new System.Windows.Forms.ComboBox();
            this.comboBoxS = new System.Windows.Forms.ComboBox();
            this.comboBoxZ = new System.Windows.Forms.ComboBox();
            this.comboBoxR = new System.Windows.Forms.ComboBox();
            this.comboBoxL = new System.Windows.Forms.ComboBox();
            this.comboBoxY = new System.Windows.Forms.ComboBox();
            this.comboBoxX = new System.Windows.Forms.ComboBox();
            this.comboBoxB = new System.Windows.Forms.ComboBox();
            this.comboBoxA = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.buttonInject = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonOpen
            // 
            this.buttonOpen.Location = new System.Drawing.Point(12, 321);
            this.buttonOpen.Name = "buttonOpen";
            this.buttonOpen.Size = new System.Drawing.Size(57, 23);
            this.buttonOpen.TabIndex = 0;
            this.buttonOpen.Text = "Open";
            this.buttonOpen.UseVisualStyleBackColor = true;
            this.buttonOpen.Click += new System.EventHandler(this.buttonOpen_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(140, 321);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(57, 23);
            this.buttonSave.TabIndex = 1;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // checkBoxControlStickFix
            // 
            this.checkBoxControlStickFix.AutoSize = true;
            this.checkBoxControlStickFix.Location = new System.Drawing.Point(6, 19);
            this.checkBoxControlStickFix.Name = "checkBoxControlStickFix";
            this.checkBoxControlStickFix.Size = new System.Drawing.Size(83, 17);
            this.checkBoxControlStickFix.TabIndex = 2;
            this.checkBoxControlStickFix.Text = "Mapping Fix";
            this.checkBoxControlStickFix.UseVisualStyleBackColor = true;
            this.checkBoxControlStickFix.CheckedChanged += new System.EventHandler(this.checkBoxControlStickFix_CheckedChanged);
            // 
            // textBoxROMSize
            // 
            this.textBoxROMSize.Enabled = false;
            this.textBoxROMSize.Location = new System.Drawing.Point(134, 12);
            this.textBoxROMSize.Name = "textBoxROMSize";
            this.textBoxROMSize.Size = new System.Drawing.Size(63, 20);
            this.textBoxROMSize.TabIndex = 3;
            this.textBoxROMSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "ROM Size (MB, Hex)";
            // 
            // checkBoxShadeRemove
            // 
            this.checkBoxShadeRemove.AutoSize = true;
            this.checkBoxShadeRemove.Location = new System.Drawing.Point(6, 42);
            this.checkBoxShadeRemove.Name = "checkBoxShadeRemove";
            this.checkBoxShadeRemove.Size = new System.Drawing.Size(129, 17);
            this.checkBoxShadeRemove.TabIndex = 5;
            this.checkBoxShadeRemove.Text = "VC Shaded Picture fix";
            this.checkBoxShadeRemove.UseVisualStyleBackColor = true;
            // 
            // checkBoxCrashesFix
            // 
            this.checkBoxCrashesFix.AutoSize = true;
            this.checkBoxCrashesFix.Location = new System.Drawing.Point(6, 19);
            this.checkBoxCrashesFix.Name = "checkBoxCrashesFix";
            this.checkBoxCrashesFix.Size = new System.Drawing.Size(120, 17);
            this.checkBoxCrashesFix.TabIndex = 6;
            this.checkBoxCrashesFix.Text = "Decomp Crashes fix";
            this.checkBoxCrashesFix.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkBoxExtendedRAM);
            this.groupBox1.Controls.Add(this.checkBoxCrashesFix);
            this.groupBox1.Controls.Add(this.checkBoxShadeRemove);
            this.groupBox1.Location = new System.Drawing.Point(12, 38);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(185, 93);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Fixes";
            // 
            // checkBoxExtendedRAM
            // 
            this.checkBoxExtendedRAM.AutoSize = true;
            this.checkBoxExtendedRAM.Location = new System.Drawing.Point(6, 65);
            this.checkBoxExtendedRAM.Name = "checkBoxExtendedRAM";
            this.checkBoxExtendedRAM.Size = new System.Drawing.Size(111, 17);
            this.checkBoxExtendedRAM.TabIndex = 7;
            this.checkBoxExtendedRAM.Text = "Extended RAM fix";
            this.checkBoxExtendedRAM.UseVisualStyleBackColor = true;
            // 
            // labelStatus
            // 
            this.labelStatus.Location = new System.Drawing.Point(12, 347);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(185, 13);
            this.labelStatus.TabIndex = 10;
            this.labelStatus.Text = "Preparing";
            this.labelStatus.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.buttonLoadMappingDefaults);
            this.groupBox2.Controls.Add(this.checkBoxLockDiag);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.labelMax);
            this.groupBox2.Controls.Add(this.textBoxN64Diag);
            this.groupBox2.Controls.Add(this.textBoxGCDiag);
            this.groupBox2.Controls.Add(this.textBoxN64Max);
            this.groupBox2.Controls.Add(this.textBoxGCMax);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.checkBoxFramewalk);
            this.groupBox2.Controls.Add(this.checkBoxControlStickFix);
            this.groupBox2.Location = new System.Drawing.Point(12, 137);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(185, 173);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Control Stick";
            // 
            // buttonLoadMappingDefaults
            // 
            this.buttonLoadMappingDefaults.Location = new System.Drawing.Point(129, 110);
            this.buttonLoadMappingDefaults.Name = "buttonLoadMappingDefaults";
            this.buttonLoadMappingDefaults.Size = new System.Drawing.Size(50, 23);
            this.buttonLoadMappingDefaults.TabIndex = 13;
            this.buttonLoadMappingDefaults.Text = "Default";
            this.buttonLoadMappingDefaults.UseVisualStyleBackColor = true;
            this.buttonLoadMappingDefaults.Click += new System.EventHandler(this.buttonLoadMappingDefaults_Click);
            // 
            // checkBoxLockDiag
            // 
            this.checkBoxLockDiag.AutoSize = true;
            this.checkBoxLockDiag.Checked = true;
            this.checkBoxLockDiag.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxLockDiag.Location = new System.Drawing.Point(6, 114);
            this.checkBoxLockDiag.Name = "checkBoxLockDiag";
            this.checkBoxLockDiag.Size = new System.Drawing.Size(100, 17);
            this.checkBoxLockDiag.TabIndex = 12;
            this.checkBoxLockDiag.Text = "Lock Diagonals";
            this.checkBoxLockDiag.UseVisualStyleBackColor = true;
            this.checkBoxLockDiag.CheckedChanged += new System.EventHandler(this.checkBoxLockDiag_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 87);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Diag";
            // 
            // labelMax
            // 
            this.labelMax.AutoSize = true;
            this.labelMax.Location = new System.Drawing.Point(6, 61);
            this.labelMax.Name = "labelMax";
            this.labelMax.Size = new System.Drawing.Size(27, 13);
            this.labelMax.TabIndex = 10;
            this.labelMax.Text = "Max";
            // 
            // textBoxN64Diag
            // 
            this.textBoxN64Diag.Enabled = false;
            this.textBoxN64Diag.Location = new System.Drawing.Point(116, 84);
            this.textBoxN64Diag.Name = "textBoxN64Diag";
            this.textBoxN64Diag.Size = new System.Drawing.Size(63, 20);
            this.textBoxN64Diag.TabIndex = 9;
            this.textBoxN64Diag.Text = "70";
            this.textBoxN64Diag.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxGCDiag
            // 
            this.textBoxGCDiag.Enabled = false;
            this.textBoxGCDiag.Location = new System.Drawing.Point(43, 84);
            this.textBoxGCDiag.Name = "textBoxGCDiag";
            this.textBoxGCDiag.Size = new System.Drawing.Size(63, 20);
            this.textBoxGCDiag.TabIndex = 8;
            this.textBoxGCDiag.Text = "75";
            this.textBoxGCDiag.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxN64Max
            // 
            this.textBoxN64Max.Enabled = false;
            this.textBoxN64Max.Location = new System.Drawing.Point(116, 58);
            this.textBoxN64Max.Name = "textBoxN64Max";
            this.textBoxN64Max.Size = new System.Drawing.Size(63, 20);
            this.textBoxN64Max.TabIndex = 7;
            this.textBoxN64Max.Text = "80";
            this.textBoxN64Max.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxN64Max.TextChanged += new System.EventHandler(this.textBoxN64Max_TextChanged);
            // 
            // textBoxGCMax
            // 
            this.textBoxGCMax.Enabled = false;
            this.textBoxGCMax.Location = new System.Drawing.Point(43, 58);
            this.textBoxGCMax.Name = "textBoxGCMax";
            this.textBoxGCMax.Size = new System.Drawing.Size(63, 20);
            this.textBoxGCMax.TabIndex = 6;
            this.textBoxGCMax.Text = "106";
            this.textBoxGCMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxGCMax.TextChanged += new System.EventHandler(this.textBoxGCMax_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(126, 42);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "To N64";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(51, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "From GC";
            // 
            // checkBoxFramewalk
            // 
            this.checkBoxFramewalk.AutoSize = true;
            this.checkBoxFramewalk.Location = new System.Drawing.Point(6, 145);
            this.checkBoxFramewalk.Name = "checkBoxFramewalk";
            this.checkBoxFramewalk.Size = new System.Drawing.Size(80, 17);
            this.checkBoxFramewalk.TabIndex = 3;
            this.checkBoxFramewalk.Text = "GC Y -> Up";
            this.checkBoxFramewalk.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.textBoxCR);
            this.groupBox3.Controls.Add(this.textBoxCL);
            this.groupBox3.Controls.Add(this.textBoxCD);
            this.groupBox3.Controls.Add(this.textBoxCU);
            this.groupBox3.Controls.Add(this.textBoxS);
            this.groupBox3.Controls.Add(this.textBoxZ);
            this.groupBox3.Controls.Add(this.textBoxR);
            this.groupBox3.Controls.Add(this.textBoxL);
            this.groupBox3.Controls.Add(this.textBoxY);
            this.groupBox3.Controls.Add(this.textBoxX);
            this.groupBox3.Controls.Add(this.textBoxB);
            this.groupBox3.Controls.Add(this.textBoxA);
            this.groupBox3.Controls.Add(this.label17);
            this.groupBox3.Controls.Add(this.label16);
            this.groupBox3.Controls.Add(this.label15);
            this.groupBox3.Controls.Add(this.label14);
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.comboBoxCR);
            this.groupBox3.Controls.Add(this.comboBoxCL);
            this.groupBox3.Controls.Add(this.comboBoxCD);
            this.groupBox3.Controls.Add(this.comboBoxCU);
            this.groupBox3.Controls.Add(this.comboBoxS);
            this.groupBox3.Controls.Add(this.comboBoxZ);
            this.groupBox3.Controls.Add(this.comboBoxR);
            this.groupBox3.Controls.Add(this.comboBoxL);
            this.groupBox3.Controls.Add(this.comboBoxY);
            this.groupBox3.Controls.Add(this.comboBoxX);
            this.groupBox3.Controls.Add(this.comboBoxB);
            this.groupBox3.Controls.Add(this.comboBoxA);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Location = new System.Drawing.Point(203, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(219, 354);
            this.groupBox3.TabIndex = 12;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Button Mapping";
            // 
            // textBoxCR
            // 
            this.textBoxCR.Location = new System.Drawing.Point(148, 316);
            this.textBoxCR.Name = "textBoxCR";
            this.textBoxCR.Size = new System.Drawing.Size(64, 20);
            this.textBoxCR.TabIndex = 37;
            this.textBoxCR.Text = "0000";
            this.textBoxCR.TextChanged += new System.EventHandler(this.textBoxA_TextChanged);
            // 
            // textBoxCL
            // 
            this.textBoxCL.Location = new System.Drawing.Point(148, 289);
            this.textBoxCL.Name = "textBoxCL";
            this.textBoxCL.Size = new System.Drawing.Size(64, 20);
            this.textBoxCL.TabIndex = 36;
            this.textBoxCL.Text = "0000";
            this.textBoxCL.TextChanged += new System.EventHandler(this.textBoxA_TextChanged);
            // 
            // textBoxCD
            // 
            this.textBoxCD.Location = new System.Drawing.Point(148, 262);
            this.textBoxCD.Name = "textBoxCD";
            this.textBoxCD.Size = new System.Drawing.Size(64, 20);
            this.textBoxCD.TabIndex = 35;
            this.textBoxCD.Text = "0000";
            this.textBoxCD.TextChanged += new System.EventHandler(this.textBoxA_TextChanged);
            // 
            // textBoxCU
            // 
            this.textBoxCU.Location = new System.Drawing.Point(148, 235);
            this.textBoxCU.Name = "textBoxCU";
            this.textBoxCU.Size = new System.Drawing.Size(64, 20);
            this.textBoxCU.TabIndex = 34;
            this.textBoxCU.Text = "0000";
            this.textBoxCU.TextChanged += new System.EventHandler(this.textBoxA_TextChanged);
            // 
            // textBoxS
            // 
            this.textBoxS.Location = new System.Drawing.Point(148, 209);
            this.textBoxS.Name = "textBoxS";
            this.textBoxS.Size = new System.Drawing.Size(64, 20);
            this.textBoxS.TabIndex = 33;
            this.textBoxS.Text = "0000";
            this.textBoxS.TextChanged += new System.EventHandler(this.textBoxA_TextChanged);
            // 
            // textBoxZ
            // 
            this.textBoxZ.Location = new System.Drawing.Point(148, 181);
            this.textBoxZ.Name = "textBoxZ";
            this.textBoxZ.Size = new System.Drawing.Size(64, 20);
            this.textBoxZ.TabIndex = 32;
            this.textBoxZ.Text = "0000";
            this.textBoxZ.TextChanged += new System.EventHandler(this.textBoxA_TextChanged);
            // 
            // textBoxR
            // 
            this.textBoxR.Location = new System.Drawing.Point(148, 154);
            this.textBoxR.Name = "textBoxR";
            this.textBoxR.Size = new System.Drawing.Size(64, 20);
            this.textBoxR.TabIndex = 31;
            this.textBoxR.Text = "0000";
            this.textBoxR.TextChanged += new System.EventHandler(this.textBoxA_TextChanged);
            // 
            // textBoxL
            // 
            this.textBoxL.Location = new System.Drawing.Point(148, 127);
            this.textBoxL.Name = "textBoxL";
            this.textBoxL.Size = new System.Drawing.Size(64, 20);
            this.textBoxL.TabIndex = 30;
            this.textBoxL.Text = "0000";
            this.textBoxL.TextChanged += new System.EventHandler(this.textBoxA_TextChanged);
            // 
            // textBoxY
            // 
            this.textBoxY.Location = new System.Drawing.Point(148, 99);
            this.textBoxY.Name = "textBoxY";
            this.textBoxY.Size = new System.Drawing.Size(64, 20);
            this.textBoxY.TabIndex = 29;
            this.textBoxY.Text = "0000";
            this.textBoxY.TextChanged += new System.EventHandler(this.textBoxA_TextChanged);
            // 
            // textBoxX
            // 
            this.textBoxX.Location = new System.Drawing.Point(148, 74);
            this.textBoxX.Name = "textBoxX";
            this.textBoxX.Size = new System.Drawing.Size(64, 20);
            this.textBoxX.TabIndex = 28;
            this.textBoxX.Text = "0000";
            this.textBoxX.TextChanged += new System.EventHandler(this.textBoxA_TextChanged);
            // 
            // textBoxB
            // 
            this.textBoxB.Location = new System.Drawing.Point(148, 47);
            this.textBoxB.Name = "textBoxB";
            this.textBoxB.Size = new System.Drawing.Size(64, 20);
            this.textBoxB.TabIndex = 27;
            this.textBoxB.Text = "0000";
            this.textBoxB.TextChanged += new System.EventHandler(this.textBoxA_TextChanged);
            // 
            // textBoxA
            // 
            this.textBoxA.Location = new System.Drawing.Point(148, 19);
            this.textBoxA.Name = "textBoxA";
            this.textBoxA.Size = new System.Drawing.Size(64, 20);
            this.textBoxA.TabIndex = 26;
            this.textBoxA.Text = "0000";
            this.textBoxA.TextChanged += new System.EventHandler(this.textBoxA_TextChanged);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(6, 319);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(42, 13);
            this.label17.TabIndex = 25;
            this.label17.Text = "C-Right";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(6, 292);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(35, 13);
            this.label16.TabIndex = 24;
            this.label16.Text = "C-Left";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(6, 265);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(45, 13);
            this.label15.TabIndex = 23;
            this.label15.Text = "C-Down";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(6, 240);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(31, 13);
            this.label14.TabIndex = 22;
            this.label14.Text = "C-Up";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(6, 211);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(29, 13);
            this.label13.TabIndex = 21;
            this.label13.Text = "Start";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 184);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(14, 13);
            this.label12.TabIndex = 20;
            this.label12.Text = "Z";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 157);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(15, 13);
            this.label11.TabIndex = 19;
            this.label11.Text = "R";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 130);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(13, 13);
            this.label10.TabIndex = 18;
            this.label10.Text = "L";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 103);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(14, 13);
            this.label9.TabIndex = 17;
            this.label9.Text = "Y";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 76);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(14, 13);
            this.label8.TabIndex = 16;
            this.label8.Text = "X";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 49);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(14, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "B";
            // 
            // comboBoxCR
            // 
            this.comboBoxCR.FormattingEnabled = true;
            this.comboBoxCR.Items.AddRange(new object[] {
            "Unmapped",
            "A",
            "B",
            "Z",
            "Start",
            "Dpad Up",
            "Dpad Down",
            "Dpad Left",
            "Dpad Right",
            "X [unused]",
            "Y [unused]",
            "L",
            "R",
            "C-Up",
            "C-Down",
            "C-Left",
            "C-Right",
            "Custom"});
            this.comboBoxCR.Location = new System.Drawing.Point(54, 316);
            this.comboBoxCR.Name = "comboBoxCR";
            this.comboBoxCR.Size = new System.Drawing.Size(88, 21);
            this.comboBoxCR.TabIndex = 13;
            this.comboBoxCR.Text = "Unmapped";
            this.comboBoxCR.SelectedIndexChanged += new System.EventHandler(this.comboBox_SelectedIndexChanged);
            // 
            // comboBoxCL
            // 
            this.comboBoxCL.FormattingEnabled = true;
            this.comboBoxCL.Items.AddRange(new object[] {
            "Unmapped",
            "A",
            "B",
            "Z",
            "Start",
            "Dpad Up",
            "Dpad Down",
            "Dpad Left",
            "Dpad Right",
            "X [unused]",
            "Y [unused]",
            "L",
            "R",
            "C-Up",
            "C-Down",
            "C-Left",
            "C-Right",
            "Custom"});
            this.comboBoxCL.Location = new System.Drawing.Point(54, 289);
            this.comboBoxCL.Name = "comboBoxCL";
            this.comboBoxCL.Size = new System.Drawing.Size(88, 21);
            this.comboBoxCL.TabIndex = 12;
            this.comboBoxCL.Text = "Unmapped";
            this.comboBoxCL.SelectedIndexChanged += new System.EventHandler(this.comboBox_SelectedIndexChanged);
            // 
            // comboBoxCD
            // 
            this.comboBoxCD.FormattingEnabled = true;
            this.comboBoxCD.Items.AddRange(new object[] {
            "Unmapped",
            "A",
            "B",
            "Z",
            "Start",
            "Dpad Up",
            "Dpad Down",
            "Dpad Left",
            "Dpad Right",
            "X [unused]",
            "Y [unused]",
            "L",
            "R",
            "C-Up",
            "C-Down",
            "C-Left",
            "C-Right",
            "Custom"});
            this.comboBoxCD.Location = new System.Drawing.Point(54, 262);
            this.comboBoxCD.Name = "comboBoxCD";
            this.comboBoxCD.Size = new System.Drawing.Size(88, 21);
            this.comboBoxCD.TabIndex = 11;
            this.comboBoxCD.Text = "Unmapped";
            this.comboBoxCD.SelectedIndexChanged += new System.EventHandler(this.comboBox_SelectedIndexChanged);
            // 
            // comboBoxCU
            // 
            this.comboBoxCU.FormattingEnabled = true;
            this.comboBoxCU.Items.AddRange(new object[] {
            "Unmapped",
            "A",
            "B",
            "Z",
            "Start",
            "Dpad Up",
            "Dpad Down",
            "Dpad Left",
            "Dpad Right",
            "X [unused]",
            "Y [unused]",
            "L",
            "R",
            "C-Up",
            "C-Down",
            "C-Left",
            "C-Right",
            "Custom"});
            this.comboBoxCU.Location = new System.Drawing.Point(54, 235);
            this.comboBoxCU.Name = "comboBoxCU";
            this.comboBoxCU.Size = new System.Drawing.Size(88, 21);
            this.comboBoxCU.TabIndex = 10;
            this.comboBoxCU.Text = "Unmapped";
            this.comboBoxCU.SelectedIndexChanged += new System.EventHandler(this.comboBox_SelectedIndexChanged);
            // 
            // comboBoxS
            // 
            this.comboBoxS.FormattingEnabled = true;
            this.comboBoxS.Items.AddRange(new object[] {
            "Unmapped",
            "A",
            "B",
            "Z",
            "Start",
            "Dpad Up",
            "Dpad Down",
            "Dpad Left",
            "Dpad Right",
            "X [unused]",
            "Y [unused]",
            "L",
            "R",
            "C-Up",
            "C-Down",
            "C-Left",
            "C-Right",
            "Custom"});
            this.comboBoxS.Location = new System.Drawing.Point(54, 208);
            this.comboBoxS.Name = "comboBoxS";
            this.comboBoxS.Size = new System.Drawing.Size(88, 21);
            this.comboBoxS.TabIndex = 9;
            this.comboBoxS.Text = "Unmapped";
            this.comboBoxS.SelectedIndexChanged += new System.EventHandler(this.comboBox_SelectedIndexChanged);
            // 
            // comboBoxZ
            // 
            this.comboBoxZ.BackColor = System.Drawing.SystemColors.Window;
            this.comboBoxZ.FormattingEnabled = true;
            this.comboBoxZ.Items.AddRange(new object[] {
            "Unmapped",
            "A",
            "B",
            "Z",
            "Start",
            "Dpad Up",
            "Dpad Down",
            "Dpad Left",
            "Dpad Right",
            "X [unused]",
            "Y [unused]",
            "L",
            "R",
            "C-Up",
            "C-Down",
            "C-Left",
            "C-Right",
            "Custom"});
            this.comboBoxZ.Location = new System.Drawing.Point(54, 181);
            this.comboBoxZ.Name = "comboBoxZ";
            this.comboBoxZ.Size = new System.Drawing.Size(88, 21);
            this.comboBoxZ.TabIndex = 8;
            this.comboBoxZ.Text = "Unmapped";
            this.comboBoxZ.SelectedIndexChanged += new System.EventHandler(this.comboBox_SelectedIndexChanged);
            // 
            // comboBoxR
            // 
            this.comboBoxR.FormattingEnabled = true;
            this.comboBoxR.Items.AddRange(new object[] {
            "Unmapped",
            "A",
            "B",
            "Z",
            "Start",
            "Dpad Up",
            "Dpad Down",
            "Dpad Left",
            "Dpad Right",
            "X [unused]",
            "Y [unused]",
            "L",
            "R",
            "C-Up",
            "C-Down",
            "C-Left",
            "C-Right",
            "Custom"});
            this.comboBoxR.Location = new System.Drawing.Point(54, 154);
            this.comboBoxR.Name = "comboBoxR";
            this.comboBoxR.Size = new System.Drawing.Size(88, 21);
            this.comboBoxR.TabIndex = 7;
            this.comboBoxR.Text = "Unmapped";
            this.comboBoxR.SelectedIndexChanged += new System.EventHandler(this.comboBox_SelectedIndexChanged);
            // 
            // comboBoxL
            // 
            this.comboBoxL.FormattingEnabled = true;
            this.comboBoxL.Items.AddRange(new object[] {
            "Unmapped",
            "A",
            "B",
            "Z",
            "Start",
            "Dpad Up",
            "Dpad Down",
            "Dpad Left",
            "Dpad Right",
            "X [unused]",
            "Y [unused]",
            "L",
            "R",
            "C-Up",
            "C-Down",
            "C-Left",
            "C-Right",
            "Custom"});
            this.comboBoxL.Location = new System.Drawing.Point(54, 127);
            this.comboBoxL.Name = "comboBoxL";
            this.comboBoxL.Size = new System.Drawing.Size(88, 21);
            this.comboBoxL.TabIndex = 6;
            this.comboBoxL.Text = "Unmapped";
            this.comboBoxL.SelectedIndexChanged += new System.EventHandler(this.comboBox_SelectedIndexChanged);
            // 
            // comboBoxY
            // 
            this.comboBoxY.FormattingEnabled = true;
            this.comboBoxY.Items.AddRange(new object[] {
            "Unmapped",
            "A",
            "B",
            "Z",
            "Start",
            "Dpad Up",
            "Dpad Down",
            "Dpad Left",
            "Dpad Right",
            "X [unused]",
            "Y [unused]",
            "L",
            "R",
            "C-Up",
            "C-Down",
            "C-Left",
            "C-Right",
            "Custom"});
            this.comboBoxY.Location = new System.Drawing.Point(54, 100);
            this.comboBoxY.Name = "comboBoxY";
            this.comboBoxY.Size = new System.Drawing.Size(88, 21);
            this.comboBoxY.TabIndex = 5;
            this.comboBoxY.Text = "Unmapped";
            this.comboBoxY.SelectedIndexChanged += new System.EventHandler(this.comboBox_SelectedIndexChanged);
            // 
            // comboBoxX
            // 
            this.comboBoxX.FormattingEnabled = true;
            this.comboBoxX.Items.AddRange(new object[] {
            "Unmapped",
            "A",
            "B",
            "Z",
            "Start",
            "Dpad Up",
            "Dpad Down",
            "Dpad Left",
            "Dpad Right",
            "X [unused]",
            "Y [unused]",
            "L",
            "R",
            "C-Up",
            "C-Down",
            "C-Left",
            "C-Right",
            "Custom"});
            this.comboBoxX.Location = new System.Drawing.Point(54, 73);
            this.comboBoxX.Name = "comboBoxX";
            this.comboBoxX.Size = new System.Drawing.Size(88, 21);
            this.comboBoxX.TabIndex = 4;
            this.comboBoxX.Text = "Unmapped";
            this.comboBoxX.SelectedIndexChanged += new System.EventHandler(this.comboBox_SelectedIndexChanged);
            // 
            // comboBoxB
            // 
            this.comboBoxB.FormattingEnabled = true;
            this.comboBoxB.Items.AddRange(new object[] {
            "Unmapped",
            "A",
            "B",
            "Z",
            "Start",
            "Dpad Up",
            "Dpad Down",
            "Dpad Left",
            "Dpad Right",
            "X [unused]",
            "Y [unused]",
            "L",
            "R",
            "C-Up",
            "C-Down",
            "C-Left",
            "C-Right",
            "Custom"});
            this.comboBoxB.Location = new System.Drawing.Point(54, 46);
            this.comboBoxB.Name = "comboBoxB";
            this.comboBoxB.Size = new System.Drawing.Size(88, 21);
            this.comboBoxB.TabIndex = 3;
            this.comboBoxB.Text = "Unmapped";
            this.comboBoxB.SelectedIndexChanged += new System.EventHandler(this.comboBox_SelectedIndexChanged);
            // 
            // comboBoxA
            // 
            this.comboBoxA.FormattingEnabled = true;
            this.comboBoxA.Items.AddRange(new object[] {
            "Unmapped",
            "A",
            "B",
            "Z",
            "Start",
            "Dpad Up",
            "Dpad Down",
            "Dpad Left",
            "Dpad Right",
            "X [unused]",
            "Y [unused]",
            "L",
            "R",
            "C-Up",
            "C-Down",
            "C-Left",
            "C-Right",
            "Custom"});
            this.comboBoxA.Location = new System.Drawing.Point(54, 19);
            this.comboBoxA.Name = "comboBoxA";
            this.comboBoxA.Size = new System.Drawing.Size(88, 21);
            this.comboBoxA.TabIndex = 2;
            this.comboBoxA.Text = "Unmapped";
            this.comboBoxA.SelectedIndexChanged += new System.EventHandler(this.comboBox_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(14, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "A";
            // 
            // buttonInject
            // 
            this.buttonInject.Location = new System.Drawing.Point(76, 321);
            this.buttonInject.Name = "buttonInject";
            this.buttonInject.Size = new System.Drawing.Size(57, 23);
            this.buttonInject.TabIndex = 13;
            this.buttonInject.Text = "Inject";
            this.buttonInject.UseVisualStyleBackColor = true;
            this.buttonInject.Click += new System.EventHandler(this.buttonInject_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(439, 375);
            this.Controls.Add(this.buttonInject);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.labelStatus);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxROMSize);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.buttonOpen);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Main";
            this.ShowIcon = false;
            this.Text = "sm64wiikit";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonOpen;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.CheckBox checkBoxControlStickFix;
        private System.Windows.Forms.TextBox textBoxROMSize;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkBoxShadeRemove;
        private System.Windows.Forms.CheckBox checkBoxCrashesFix;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox checkBoxExtendedRAM;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox checkBoxFramewalk;
        private System.Windows.Forms.TextBox textBoxGCMax;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxN64Diag;
        private System.Windows.Forms.TextBox textBoxGCDiag;
        private System.Windows.Forms.TextBox textBoxN64Max;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label labelMax;
        private System.Windows.Forms.CheckBox checkBoxLockDiag;
        private System.Windows.Forms.Button buttonLoadMappingDefaults;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboBoxCR;
        private System.Windows.Forms.ComboBox comboBoxCL;
        private System.Windows.Forms.ComboBox comboBoxCD;
        private System.Windows.Forms.ComboBox comboBoxCU;
        private System.Windows.Forms.ComboBox comboBoxS;
        private System.Windows.Forms.ComboBox comboBoxZ;
        private System.Windows.Forms.ComboBox comboBoxR;
        private System.Windows.Forms.ComboBox comboBoxL;
        private System.Windows.Forms.ComboBox comboBoxY;
        private System.Windows.Forms.ComboBox comboBoxX;
        private System.Windows.Forms.ComboBox comboBoxB;
        private System.Windows.Forms.ComboBox comboBoxA;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox textBoxCR;
        private System.Windows.Forms.TextBox textBoxCL;
        private System.Windows.Forms.TextBox textBoxCD;
        private System.Windows.Forms.TextBox textBoxCU;
        private System.Windows.Forms.TextBox textBoxS;
        private System.Windows.Forms.TextBox textBoxZ;
        private System.Windows.Forms.TextBox textBoxR;
        private System.Windows.Forms.TextBox textBoxL;
        private System.Windows.Forms.TextBox textBoxY;
        private System.Windows.Forms.TextBox textBoxX;
        private System.Windows.Forms.TextBox textBoxB;
        private System.Windows.Forms.TextBox textBoxA;
        private System.Windows.Forms.Button buttonInject;
    }
}

