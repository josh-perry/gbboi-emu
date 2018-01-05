namespace gbboi_emu
{
    public static partial class Opcodes
    {
        /// <summary>
        /// LD SP,nn
        /// Load 16-bit immediate into SP
        /// </summary>
        /// <param name="r"></param>
        /// <param name="i"></param>
        public static void _0x31(Registers registers, Instruction instruction)
        {
            registers.SP.Value = instruction.NN;
        }
    }
}
