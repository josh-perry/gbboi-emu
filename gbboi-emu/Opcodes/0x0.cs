using System;

namespace gbboi_emu
{
    public partial class Opcodes
    {
        /// <summary>
        /// NOP
        /// No operation
        /// </summary>
        /// <param name="registers"></param>
        public void _0x00(Stack stack, Registers registers, Instruction instruction, IMemory memory)
        {
            registers.PC.Value += 1;
        }
    }
}
