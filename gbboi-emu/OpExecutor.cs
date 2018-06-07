using System.Collections.Generic;
using gbboi_emu.Opcodes;

namespace gbboi_emu
{
    public class OpExecutor
    {
        public Dictionary<int, IOpcode> Ops;

        public Dictionary<int, IOpcode> ExtendedOps { get; set; }

        public OpExecutor()
        {
            Ops = new Dictionary<int, IOpcode>
            {
                {0x0000, new _0x00()},

                {0x0100, new _0x01()},
                {0x2100, new _0x21()},
                {0x3100, new _0x31()},
                {0x3200, new _0x32()},
                {0x5000, new _0x50()},
                {0xCE00, new _0xCE()},
                {0x6600, new _0x66()},
                {0xAF00, new _0xAF()},
                {0xC300, new _0xC3()},
                {0xCC00, new _0xCC()},
                {0xFF00, new _0xFF()},

                // Unsupported opcodes
                {0xD300, new UnsupportedOpcode()},
                {0xDB00, new UnsupportedOpcode()},
                {0xDD00, new UnsupportedOpcode()},
                {0xE300, new UnsupportedOpcode()},
                {0xE400, new UnsupportedOpcode()},
                {0xEB00, new UnsupportedOpcode()},
                {0xEC00, new UnsupportedOpcode()},
                {0xED00, new UnsupportedOpcode()},
                {0xF200, new UnsupportedOpcode()},
                {0xF400, new UnsupportedOpcode()},
                {0xFC00, new UnsupportedOpcode()},
                {0xFD00, new UnsupportedOpcode()}
            };

            ExtendedOps = new Dictionary<int, IOpcode>
            {
                {0xCB7C, new _0xCB7C()}
            };
        }
    }
}
