# at 80004f00 = 1000
# inputs f0, f1, f2, f3
# should perform fctiwz f2, f2 & fctiwz f3, f3

# at 80004f00 = 1000
.quad 0x3FF0000000000000 # One
.quad 0x405a800000000000 # Max GC
.quad 0x4052800000000000 # Diagonal GC

.quad 0x4054000000000000 # Max N64
.quad 0x4051800000000000 # Diagonal N64

.quad 0x0000000000000000 # Zero

# at 80004f28 = 1028
stwu %r1, -0x78(%r1)
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
stw %r4, 0xC(%r1)

lis %r3, 0x8000

fabs %f4, %f2 # x
fabs %f5, %f3 # y

lfd %f31, 0x4f20(%r3)
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
fmr %f5, %f6
swap_end:

lfd %f28, 0x4f00(%r3) # M
lfd %f29, 0x4f08(%r3) # slope A
lfd %f30, 0x4f10(%r3) # N
lfd %f31, 0x4f18(%r3) # slope B
lfd %f10, 0x4EF8(%r3) # one

fdiv %f4, %f4, %f28 # x
fdiv %f5, %f5, %f28 # y

fmadd %f6, %f5, %f29, %f4 # Ay+x = x/x0
fmadd %f7, %f5, %f31, %f4 # By+x

fdiv %f8, %f6, %f7 # mult
fsub %f8, %f8, %f10 # mult-1

fmadd %f9, %f8, %f6, %f10 # (mult-1)*(x/x0) + 1
fmul %f9, %f9, %f30
fdiv %f9, %f9, %f28

# apply
fmul %f2, %f2, %f9
fmul %f3, %f3, %f9

ehd:

lis %r4, 0x809f
lbz %r4, 0x38b8(%r4)
andi. %r4, %r4, 0x08
cmpwi %r4, 0
ble ehd2
lfd %f2, 0x4f00(%r3)
ehd2:

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
lwz %r4, 0xc(%r1)

addi %r1, %r1, 0x78

blr
