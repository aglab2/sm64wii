.orga 0x101B84
.area 0x48
	ADDIU SP, SP, 0xffe8
	SW RA, 0x14(SP)
	
	LI A0, 0x80400000
	JAL 0x80324570
	LI A1, 0x400000
	
	LI A0, 0x80402000
	LI A1, 0xD76AA0
	LI.l A2, 0xD84AA0
	JAL 0x80278504
	LI.u A2, 0xD84AA0
	
	LI A0, 0x80400000
	JAL 0x80324610
	LI A1, 0x400000
	
	LW RA, 0x14(SP)
	JR RA
	ADDIU SP, SP, 0x18
.endarea