namespace gbboi_emu
{
    public partial class Opcodes
    {
        /// <summary>
        /// LD SP,nn
        /// Load 16-bit immediate into SP
        /// </summary>
        /// <param name="r"></param>
        /// <param name="i"></param>
        public void _0x31(Registers registers, Instruction instruction)
        {
            registers.SP.Value = instruction.NN;
            registers.PC.Value += 3;
        }
    }
}
