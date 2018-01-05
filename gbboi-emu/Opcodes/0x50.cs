namespace gbboi_emu
{
    public static partial class Opcodes
    {
        /// <summary>
        /// LD D,B
        /// Copy B to D
        /// </summary>
        /// <param name="registers"></param>
        public static void _0x50(Registers registers)
        {
            registers.D.Value = registers.B.Value;
        }
    }
}
