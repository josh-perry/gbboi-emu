namespace gbboi_emu
{
    public partial class OpExecutor
    {
        /// <summary>
        /// LD H,(HL)
        /// Copy value pointed by HL to H
        /// No operation
        /// </summary>
        public void _0x66(Stack stack, Registers registers, Instruction instruction, IMemory memory)
        {
            registers.H.Value = memory.Bytes[registers.HL.Value];

            registers.PC.Value += 1;
        }
    }
}
