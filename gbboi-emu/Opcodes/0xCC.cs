namespace gbboi_emu
{
    public partial class Opcodes
    {
        /// <summary>
        /// CALL Z,nn
        /// Call routine at 16-bit location if last result was zero
        /// </summary>
        /// <param name="registers"></param>
        /// <param name="instruction"></param>
        /// <param name="memory"></param>
        public void _0xCC(Stack stack, Registers registers, Instruction instruction, IMemory memory)
        {
            // Only call the routine if the zero flag is set
            if (!registers.F.ZeroFlag)
            {
                return;
            }

            stack.Call(instruction.NN, registers, memory);
        }
    }
}
