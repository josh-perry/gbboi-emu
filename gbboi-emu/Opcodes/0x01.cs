namespace gbboi_emu
{
    public partial class OpExecutor
    {
        /// <summary>
        /// LD BC,nn
        /// Load 16-bit immediate into BC
        /// </summary>
        public void _0x01(Stack stack, Registers registers, Instruction instruction, IMemory memory)
        {
            registers.BC.Value = instruction.NN;
            registers.PC.Value += 3;
        }
    }
}
