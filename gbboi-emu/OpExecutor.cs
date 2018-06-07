using System.Collections.Generic;

namespace gbboi_emu
{
    public partial class OpExecutor
    {
        public delegate void Opcode(Stack s, Registers r, Instruction i, IMemory m);

        public Dictionary<int, Opcode> Ops;

        public OpExecutor()
        {
            Ops = new Dictionary<int, Opcode>
            {
                {0x0000, _0x00},

                {0x0100, _0x01},
                {0x2100, _0x21},
                {0x3100, _0x31},
                {0x3200, _0x32},
                {0x5000, _0x50},
                {0xCE00, _0xCE},
                {0x6600, _0x66},
                {0xAF00, _0xAF},
                {0xC300, _0xC3},
                {0xCC00, _0xCC},
                {0xFF00, _0xFF},

                // Unsupported opcodes
                {0xD300, UnsupportedOpcode},
                {0xDB00, UnsupportedOpcode},
                {0xDD00, UnsupportedOpcode},
                {0xE300, UnsupportedOpcode},
                {0xE400, UnsupportedOpcode},
                {0xEB00, UnsupportedOpcode},
                {0xEC00, UnsupportedOpcode},
                {0xED00, UnsupportedOpcode},
                {0xF200, UnsupportedOpcode},
                {0xF400, UnsupportedOpcode},
                {0xFC00, UnsupportedOpcode},
                {0xFD00, UnsupportedOpcode}
            };
        }
    }
}
