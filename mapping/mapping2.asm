# at 80004f00 = 1000
# inputs f0, f1, f2, f3
# should perform fctiwz f2, f2 & fctiwz f3, f3

# at 80004f00 = 1000
.quad 0x405a800000000000 # Max GC
.quad 0x4052800000000000 # Diagonal GC

.quad 0x4054000000000000 # Max N64
.quad 0x4051800000000000 # Diagonal N64

.quad 0x0000000000000000 # Zero

# at 80004f28 = 1028
stwu %r1, -0x68(%r1)
stfd %f4, 0x68(%r1)
stfd %f5, 0x60(%r1)
stfd %f6, 0x58(%r1)
stfd %f7, 0x50(%r1)
stfd %f8, 0x48(%r1)
stfd %f9, 0x40(%r1)
stfd %f10, 0x38(%r1)
stfd %f11, 0x30(%r1)
stfd %f28, 0x28(%r1)
stfd %f29, 0x20(%r1)
stfd %f30, 0x18(%r1)
stfd %f31, 0x10(%r1)
stw %r0, 0x8(%r1)
stw %r3, 0x4(%r1)

lis %r3, 0x8000
addi %r3, %r3, 0x4f00

fabs %f4, %f2 # x
fabs %f5, %f3 # y

lfd %f31, 0x20(%r3)
fcmpo %cr0, %f4, %f31
bne %cr0, nozero
fcmpo %cr0, %f5, %f31
bne %cr0, nozero
b ehd
nozero:

# Swapping
li %r0, 0x0
fcmpo %cr0, %f5, %f4
ble swap_end
li %r0, 0x1
fmr %f6, %f4
fmr %f4, %f5
fmr %f5, %f4
swap_end:

lfd %f28, 0x0(%r3) # M
lfd %f29, 0x8(%r3) # m
lfd %f30, 0x10(%r3) # N
lfd %f31, 0x18(%r3) # n

fmul %f6, %f30, %f29
fmsub %f6, %f28, %f31, %f6 
fmul %f6, %f5, %f6 # multiplierDividend

fmul %f7, %f31, %f5
fmsub %f7, %f30, %f5, %f7
fmadd %f7, %f31, %f4, %f7
fmul %f7, %f29, %f7 # multiplierDivisor

fmul %f8, %f29, %f4
fmadd %f8, %f28, %f5, %f8
fnmsub %f8, %f29, %f5, %f8 # degradorDividend

fmul %f9, %f29, %f28 # degradorDivisor

fmul %f10, %f6, %f8 # totalDividend
fmul %f11, %f7, %f9 # totalDivisor

fadd %f6, %f10, %f11
fmul %f6, %f6, %f30 # divident

fmul %f7, %f11, %f28 # divisor

# apply
fmul %f2, %f2, %f6
fdiv %f2, %f2, %f7

fmul %f3, %f3, %f6
fdiv %f3, %f3, %f7

# Unswapping
#cmpi %cr0, %r0, 0x0
#beq unswap_end
#fmr %f4, %f2
#fmr %f2, %f3
#fmr %f3, %f4
#unswap_end:

ehd:
fctiwz %f2, %f2
fctiwz %f3, %f3

lfd %f4, 0x68(%r1)
lfd %f5, 0x60(%r1)
lfd %f6, 0x58(%r1)
lfd %f7, 0x50(%r1)
lfd %f8, 0x48(%r1)
lfd %f9, 0x40(%r1)
lfd %f10, 0x38(%r1)
lfd %f11, 0x30(%r1)
lfd %f28, 0x28(%r1)
lfd %f29, 0x20(%r1)
lfd %f30, 0x18(%r1)
lfd %f31, 0x10(%r1)
lwz %r0, 0x8(%r1)
lwz %r3, 0x4(%r1)

addi %r1, %r1, 0x68

blr
