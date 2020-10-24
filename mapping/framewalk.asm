# 809f38b8 inputs
# dleft  0001
# dright 0002
# ddown  0004
# dup    0008
# z 0010
# r 0020
# l 0040
# a 0100
# b 0200
# x 0400
# y 0800
# start 1000

# at 80004f00 = 1000
# inputs f2, f3
# should perform fctiwz f2, f2 & fctiwz f3, f3

# at 80004f00 = 1000
.quad 0x405a800000000000 # Max GC
.quad 0x4052800000000000 # Diagonal GC

.quad 0x4054000000000000 # Max N64
.quad 0x4051800000000000 # Diagonal N64

.quad 0x0000000000000000 # Zero

# at 80004f28 = 1028
stwu %r1, -0x8(%r1)
stw %r3, 0x0(%r1)
stw %r4, 0x4(%r1)

lis %r3, 0x8000

lis %r4, 0x809f
lbz %r4, 0x38b8(%r4)
andi. %r4, %r4, 0x08
cmpwi %r4, 0
ble ehd

lfd %f2, 0x4f00(%r3)

ehd:
fctiwz %f2, %f2
fctiwz %f3, %f3

lwz %r4, 0x4(%r1)
lwz %r3, 0x0(%r1)

addi %r1, %r1, 0x8

blr
