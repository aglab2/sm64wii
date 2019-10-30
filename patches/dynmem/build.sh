clang -Wall -Wdouble-promotion -Os -mtune=vr4300 -march=mips2 --target=mips-img-elf -fomit-frame-pointer -G0 -flto -mfp32 ./cmd17.c -c -o cmd17.o
ld.lld -o tmp --oformat binary -T ldscript -M cmd17.o