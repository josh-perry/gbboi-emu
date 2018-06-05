namespace gbboi_emu
{
    public partial class Opcodes
    {
        /// <summary>
        /// LD D,B
        /// Copy B to D
        /// </summary>
        /// <param name="registers"></param>
        public void _0x50(Registers registers)
        {
            registers.D.Value = registers.B.Value;
            registers.PC.Value += 1;
        }
    }
}
