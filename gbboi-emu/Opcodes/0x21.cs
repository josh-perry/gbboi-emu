namespace gbboi_emu
{
    public partial class OpExecutor
    {
        /// <summary>
        /// LD HL,nn
        /// Load 16-bit immediate into HL
        /// </summary>
        public void _0x21(Stack stack, Registers registers, Instruction instruction, IMemory memory)
        {
            registers.HL.Value = instruction.NN;
            registers.PC.Value += 3;
        }
    }
}
