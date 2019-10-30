.definelabel cmd17, 0x80402000
.definelabel cmd1B, 0x80402198
.definelabel cmd1C, 0x804021C0
.definelabel loadarea, 0x804021E8

.orga 0x100100
	LUI V0, 0x806A

.orga 0x108694
	.dw cmd17

.orga 0x1086A4
	.dw cmd1B
	.dw cmd1C

; cmd load area
.orga 0x1203700
	ADDIU SP, SP, -0x18
	SW RA, 0x14(SP)
	
	; Prepare areaId
	SLL A0, A0, 4
	SW A0, 0x10(SP)
	
	; Check if need to fixup bank E
	JAL 0x80277F50
	LUI A0, 0x1900
	; V0=bank 19 address
	LW T1, 0x5FFC(V0)
	LI T2, 0x4BC9189A
	
	BNE T1, T2, end
	NOP
	
	; Fixup bank E
	; Find needed information about area
	LW A0, 0x10(SP)
	ADD V0, V0, A0
	
	SRL A0, A0, 4
	LW A1, 0x5F00(V0)
	LW A2, 0x5F04(V0)
	JAL loadarea
	LB A3, 0x5F0F(V0)

end:
	LUI T6, 0x8033
	LW T6, 0xDDCC(T6)
	LW RA, 0x14(SP)
	JR RA
	ADDIU SP, SP, 0x18
	
; vc rng manip
	NOP	
	NOP	
	NOP	
	NOP	
	NOP	
	NOP	
	NOP	
	NOP