namespace gbboi_emu
{
    public partial class OpExecutor
    {
        /// <summary>
        /// LD D,B
        /// Copy B to D
        /// </summary>
        /// <param name="registers"></param>
        public void _0x50(Stack stack, Registers registers, Instruction instruction, IMemory memory)
        {
            registers.D.Value = registers.B.Value;
            registers.PC.Value += 1;
        }
    }
}
