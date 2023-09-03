.orga 0x366C
	JAL 0x80403F00

.headersize 0x80402000-0xCED6D0 ;-0x1200000
.org 0x80403EF8
	.dw 0x00000001
.org 0x80403EFC
	.dw 0x00000000
.org 0x80403F00
	ADDIU SP, SP, -0x20
	SW RA, 0x14(SP)

	LW T9, 0x80403EF8
	BEQ T9, R0, noinit
	NOP
	
	SW A0, 0x18(SP)
	LI A1, 0x1800000
	LI A2, 0x1810000
	JAL 0x80278504
	LUI A0, 0x8041
	
	LW A0, 0x18(SP)
	SW R0, 0x80403EF8

noinit:

	LW T0, 0x80403EFC
	LI T1, 0x80410000
	ADDU T2, T1, T0
	
	LW T3, 0x0(T2)
	
	ADDIU T0, T0, 4
	SW T0, 0x80403EFC
	
	SW T3, 0x0(A0)
	LW RA, 0x14(SP)
	JR RA
	ADDIU SP, SP, 0x20
	
	NOP
	NOP
	NOP
	NOP
	NOP
	NOP
	NOP
	NOP
	NOP
	NOP