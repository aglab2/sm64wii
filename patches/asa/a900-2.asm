.orga 0x86228
	JAL 0x8040A900
	NOP
	LW RA, 0x14(SP)
	JR RA
	ADDIU SP, SP, 0x18

.orga 0x120a900
	addiu sp, sp, -0x18
	sw ra, 0x14(Sp)
lui t0, 0x8020
lbu t1, 0x78d1 (T0)
subiu t1, t1, 0x1
blez t1, normal
lui t0, 0x8034
lwc1 f0, 0xb1b0 (T0)
swc1 f0, 0xB22C (T0) //remove fall dmg
lui t9, 0x8041
lb t8, 0x8fff (T9) //dorrie mode
slti t7, t8, 0x1
beq t7, r0, normal
lui t0, 0x8034
lw t1, 0xb17c (T0)
andi t2, t1, 0x1c0
ori t3, r0, 0x80 //in air
bne t3, t2, reset
lui t8, 0x0100
ori t8, t8, 0x0882 //triple jump
beq t8, t1, supercount
lui t7, 0x0100
ori t7, t7, 0x088C //falling
beq t7, t1, supercount
lui t8, 0x0300
ori t8, t8, 0x08A0 //jumping holding object
beq t8, t1, normal
lui t2, 0x0300
lui t9, 0xffff
and t3, t1, t9
bne t3, t2, normal
supercount:
lui t8, 0x0300
ori t8, t8, 0x0886 //wall jump
beq t1, t8, wallset
lh t4, 0xb22a (T0) //ba in mario struct
slt t5, t4, r0
bne t5, r0, set
lbu t3, 0xb198 (T0) //frames since a press
beq t4, r0, normal
lui t5, 0x8033
bne t3, r0, normal
lw t5, 0xD580 (T5)
andi t5, t5, 0x00ff
subiu t5, t5, 0x2
lui t6, 0x8041
lh t6, 0x8ffc (T6) //VI
beq t6, t5, normal
super:
lui t8, 0x0100
ori t7, r0, 0x2
or a1, r0, r0
beq t7, t4, nosparkles
ori t8, t8, 0x0882 //triple jump
lui a1, 0x0001
lui t8, 0x0300
ori t8, t8, 0x08AF //sparkly triple jump
lui a1, 0x0001
nosparkles:
sw t8, 0xb17c (T0)
ori t9, r0, 0x30
mtc1 t9, f10
cvt.s.w f10, f10
swc1 f10, 0xb1bc (T0) //mario y spd
subiu t4, t4, 0x1
sh t4, 0xb22a (T0)
lui a0, 0x242e //waha
addu a0, a0, a1 //yipee
jal 0x802ca144 //play sound
ori a0, a0, 0x0081
beq r0, r0, normal
nop
 
reset:
lui t0, 0x8034
ori t2, r0, 0xffff
beq r0, r0, normal
sh t2, 0xb22a (T0)
 
 
wallset:
lui t0, 0x8034
lui t1, 0x0300
ori t1, t1, 0x0880 //double jump
sw t1, 0xb17c (T0)
 
 
 
set:
lui t0, 0x8034
ori t2, r0, 0x2
sh t2, 0xb22a (T0)
lui t3, 0x8033
lw t3, 0xD580 (T3)
andi t3, t3, 0x00ff
lui t4, 0x8041
sh t3, 0x8ffc (T4) //VI
 
//8007ec20 = start of bank 4
 
 
//0x0,4 = overalls dark
//0x8,c = overalls light
 
//0x18,1c = shirt/hat dark
//0x20,24 = shirt/hat light
 
//0x60,64 = face dark
//0x68,6c = face light
 
//0x80,84 = back hair dark
//0x78,7c = back hair light
 
//0x30,34 = gloves dark
//0x38,3c = gloves light
 
//0x48,4c = shoes dark
//0x50,54 = shoes light
 
 
normal:
jal 0x8040a500
nop

	LW RA, 0x14(SP)
	JR RA
	ADDIU SP, SP, 0x18
	nop
	nop
	nop
	nop
	nop
	nop
	nop
	nop
 
.orga 0x120a500
	addiu sp, sp, -0x18
	sw ra, 0x14(Sp)
	
jal 0x80277f50
lui a0, 0x0400 //start of bank 4 in v0
 
lui t0, 0x8020
lui t9, 0x8033
lh t9, 0xDDF4 (T9) //file
subiu t9, t9, 0x1
ori t8, r0, 0x2
multu t9, t8
mflo t9
addu t0, t0, t9 //add file times 2
lbu t1, 0x78d4 (T0) //yips times
xori t1, t1, 0x3f
beq t1, r0, yipshade
lbu t2, 0x78d5 (T0) //my times
xori t1, t2, 0x3f
bne t1, r0, end
lui t9, 0x1f1f
ori t9, t9, 0x1f00
sw t9, 0x18 (V0) //shirt dark
lui t9, 0x1010
ori t9, t9, 0xff00
sw t9, 0x20 (V0) //shirt light
lui t9, 0x3000
ori t9, t9, 0x7f00
sw t9, 0x0 (V0) //overall dark
lui t9, 0x3000
sw t9, 0x8 (V0) //overall light
lui t9, 0x7f7f
sw t9, 0x30 (V0) //glovedark
beq r0, r0, end
yipshade:
lui t9, 0x7020
ori t9, t9, 0xff00
sw t9, 0x60 (V0) //face dark
sh t0, 0x30 (V0)//gloves dark
lui t9, 0xff00
ori t9, t9, 0xff
sw t9, 0x38 (V0) //gloves light
lui t0, 0x0020
or t9, t9, r0
sw t9, 0x0 (V0) //overalls dark
lui t9, 0x0090
ori t9, t9, 0x3000
sw t9, 0x8 (V0) //overals light
sw r0, 0x18 (V0) //shirt light
lui t9, 0x9050
ori t9, t9, 0x6000
sw t9, 0x20 (V0) //shirt light
 
 
end:
lw ra, 0x0014 (SP)
jr ra
addiu sp, sp, 0x18
