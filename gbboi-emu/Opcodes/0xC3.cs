using System;

namespace gbboi_emu
{
    public partial class Opcodes
    {
        /// <summary>
        /// JP nn
        /// Absolute jump to 16-bit location
        /// </summary>
        public void _0xC3(Stack stack, Registers registers, Instruction instruction, IMemory memory)
        {
            registers.PC.Value = instruction.NN;
        }
    }
}
