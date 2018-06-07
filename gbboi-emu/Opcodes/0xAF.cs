using System;

namespace gbboi_emu
{
    public partial class OpExecutor
    {
        /// <summary>
        /// XOR A
        /// Logical XOR A against A
        /// </summary>
        /// <param name="registers"></param>
        public void _0xAF(Stack stack, Registers registers, Instruction instruction, IMemory memory)
        {
            registers.A.Value ^= registers.A.Value;
            registers.PC.Value += 1;
        }
    }
}
