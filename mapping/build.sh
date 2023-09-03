powerpc-eabi-as.exe mapping3.asm -o mapping.o
powerpc-eabi-objcopy.exe -O binary mapping.o mapping

powerpc-eabi-as.exe hook.asm -o hook.o
powerpc-eabi-objcopy.exe -O binary hook.o hook

powerpc-eabi-as.exe framewalk.asm -o framewalk.o
powerpc-eabi-objcopy.exe -O binary framewalk.o framewalk

powerpc-eabi-as.exe map_framewalk3.asm -o map_framewalk.o
powerpc-eabi-objcopy.exe -O binary map_framewalk.o map_framewalk