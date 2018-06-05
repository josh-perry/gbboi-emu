using System;

namespace gbboi_emu
{
    public partial class Opcodes
    {
        /// <summary>
        /// XOR A
        /// Logical XOR A against A
        /// </summary>
        /// <param name="registers"></param>
        public void _0xAF(Registers registers)
        {
            registers.A.Value ^= registers.A.Value;
            registers.PC.Value += 1;
        }
    }
}
