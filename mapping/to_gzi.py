import struct 
import sys

with open(sys.argv[1], "rb") as f:
    i = 0x1028
    while True:
        chunk = f.read(4)
        if chunk:
            print(f"0304 0000{hex(i)[2:]} {chunk.hex()}")
        else:
            break
        i += 4