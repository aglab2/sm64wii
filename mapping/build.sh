powerpc-eabi-as.exe mapping2.asm -o mapping.o
powerpc-eabi-objcopy.exe -O binary mapping.o mapping

powerpc-eabi-as.exe hoo.asm -o hoo.o
powerpc-eabi-objcopy.exe -O binary hoo.o hoo