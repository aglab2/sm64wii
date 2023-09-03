guMtxIdentF = 0x80329550;
guNormalize = 0x803296C0;
sinf = 0x80325480;
cosf = 0x80325310;
sqrtf = 0x80323A50;

ENTRY(guPerspectiveF)

SECTIONS 
{
  .sm64 0x80324DE0 : 
  {
    *(.text)
    *(.text.*)
    *(.data)
    *(.data.*)
    *(.bss)
    *(.bss.*)
    *(.rodata)
    *(.rodata.*)
  }
  
  /DISCARD/ :
  {
	*(.MIPS.abiflags)
	*(.gnu.attributes)
	*(.mdebug.abi32)
	*(.comment)
	*(.pdr)
	*(.reginfo)
  }
}