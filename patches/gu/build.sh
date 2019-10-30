CFLAGS="-Wall -Wdouble-promotion -Os -mtune=vr4300 -march=mips2 --target=mips-img-elf -fomit-frame-pointer -G0 -mno-check-zero-division -c"

clang ${CFLAGS} ./guPerspectiveF.c -o guPerspectiveF.o
clang ${CFLAGS} ./guNormalize.c    -o guNormalize.o
clang ${CFLAGS} ./guOrthoF.c 	   -o guOrthoF.o
clang ${CFLAGS} ./guRotateF.c      -o guRotateF.o

ld.lld.exe -M ./guPerspectiveF.o --oformat binary -T guPerspectiveF.ld -o ./guPerspectiveF.bin
ld.lld.exe -M ./guNormalize.o    --oformat binary -T guNormalize.ld    -o ./guNormalize.bin
ld.lld.exe -M ./guOrthoF.o       --oformat binary -T guOrthoF.ld       -o ./guOrthoF.bin
ld.lld.exe -M ./guRotateF.o      --oformat binary -T guRotateF.ld      -o ./guRotateF.bin