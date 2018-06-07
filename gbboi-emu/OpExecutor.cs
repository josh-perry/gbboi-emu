using System;
using System.Collections.Generic;
using System.Linq;
using gbboi_emu.Exceptions;

namespace gbboi_emu
{
    public class OpExecutor
    {
        public delegate void Opcode(Stack s, Registers r, Instruction i, IMemory m);

        public Dictionary<int, Opcode> Ops;

        public Opcodes Opcodes;

        public OpExecutor()
        {
            Opcodes = new Opcodes();

            Ops = new Dictionary<int, Opcode>
            {
                {0x0000, Opcodes._0x00},

                {0x0100, Opcodes._0x01},
                {0x2100, Opcodes._0x21},
                {0x3100, Opcodes._0x31},
                {0x3200, Opcodes._0x32},
                {0x5000, Opcodes._0x50},
                {0xCE00, Opcodes._0xCE},
                {0x6600, Opcodes._0x66},
                {0xAF00, Opcodes._0xAF},
                {0xC300, Opcodes._0xC3},
                {0xCC00, Opcodes._0xCC},
                {0xFF00, Opcodes._0xFF},

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

        public void UnsupportedOpcode(Stack s, Registers r, Instruction i, IMemory m)
        {
            throw new OperationNotSupportedByCpuException(i.Opcode);
        }
    }
}
