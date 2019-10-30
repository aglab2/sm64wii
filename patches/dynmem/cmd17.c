// 80402000

#pragma pack(push, 1)
struct cmd17_t
{
    char me;
    char len;
    char ext;
    char bank;
    int from;
    int to;
};

struct AreaBankDescriptor
{
    int from;
    int to;
    int reserved8;
    char reverved12;
    char reverved13;
    char reverved14;
    char flags;
};
#pragma pack(pop)

struct MIO0Header
{
    char signature[4];
    int rawSize;
    int compOffs;
    int rawOffs;
};

#define NULL 0

#define LEVEL_BANK 0xE

extern char* currentLevelScriptCmd;
    
void DmaCopy(void* dst, int from, int to);
void DynamicIndexCopy(int bank, int from, int to, int side);
void MIO0Unpack(void* packed, void* unpacked);

void* SegmentedToVirtual(int);

void SetSegment(int bank, void* ptr);
void* GetSegment(int bank);

void cmd1B();
void cmd1C();

char* ExtAllocSaved = (char*) 0x80420000;
char* ExtAllocCur   = (char*) 0x80420000;

#define ALIGN16(val) (((val) + 0xF) & ~0xF)

static void *ExtAlloc(int size)
{
    void* ptr = ExtAllocCur;
    ExtAllocCur += ALIGN16(size);
    return ptr;
}

static void ExtFree(int size)
{
    ExtAllocCur -= size;
}

static void ExtPush()
{
    ExtAllocSaved = ExtAllocCur;
}

static void ExtPop()
{
    ExtAllocCur = ExtAllocSaved;
}

static void DynamicExtIndexCopy(int bank, int from, int to)
{
    void* ptr;
    int length = to - from;
    if (bank == LEVEL_BANK)
    {
        struct AreaBankDescriptor* areas = SegmentedToVirtual(0x19005F00);
        if (*(int*)((char*)areas + 0xFC) == 0x4BC9189A)
        {
            for (int i = 0; i < 8; i++)
            {
                if (areas[i].from == 0 || areas[i].to <= areas[i].from)
                    continue;
                    
                int areaSegSize;
                // mio0 compression
                if (areas[i].flags & 0x02)
                {
                    struct MIO0Header header;
                    DmaCopy(&header, areas[i].from, areas[i].from + sizeof(struct MIO0Header));
                    areaSegSize = header.rawSize;
                }
                else
                {
                    areaSegSize = areas[i].to - areas[i].from;
                }
                if (areaSegSize > length)
                    length = areaSegSize;
            }
        }
    }
    ptr = ExtAlloc(length);
    DmaCopy(ptr, from, to);
    SetSegment(bank, ptr);
}
    
// Outside
void ExtCmd17()
{
    volatile struct cmd17_t* cmd = (struct cmd17_t*)currentLevelScriptCmd;
    if (cmd->ext)
    {
        DynamicExtIndexCopy(cmd->bank, cmd->from, cmd->to);
    }
    else
    {
        DynamicIndexCopy(cmd->bank, cmd->from, cmd->to, 0);
    }
    currentLevelScriptCmd += cmd->len;
}

// Outside
void ExtCmd1B()
{
    ExtPush();
    cmd1B();
}

// Outside
void ExtCmd1C()
{
    ExtPop();
    cmd1C();
}

// Outside
void loadarea(int area, int from, int to, int mio0)
{
    void* target = GetSegment(LEVEL_BANK);
    if (!mio0)
    {
        DmaCopy(target, from, to);
    }
    else
    {
        int size = to - from;
        struct MIO0Header* compressed = ExtAlloc(size);
        DmaCopy(compressed, from, to);
        MIO0Unpack(compressed, target);
        ExtFree(size);
    }
}
