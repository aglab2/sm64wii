.orga 0x21B428
	.dw 0x802B25AC
.orga 0x21B414
	.dw 0x802B2664

.orga 0x6D5AC
	ADDIU SP, SP, -0x20
	SW RA, 0x14(SP)
	
	LW T0, 0x80361160
	LW T0, 0x154(T0)
	BNEZ T0, ehd
	NOP
	
	JAL 0x80277F50
	LI A0, 0x07000000
	SW V0, 0x18(SP)
	
	LI T0, 0x19800 ;LI A0, 0x80639800
	LI A1, 0x1990000
	LI A2, 0x1994000
	JAL 0x80278504
	ADD A0, V0, T0
	
	LW V0, 0x18(SP)
	LI T0, 0x23A58 ;LI A0, 0x80643A58
	LI A1, 0x1994000
	LI A2, 0x19940F0
	JAL 0x80278504
	ADD A0, V0, T0
	
ehd:
	LW RA, 0x14(SP)
	JR RA
	ADDIU SP, SP, 0x20
	
.orga 0x6D668
	NOP