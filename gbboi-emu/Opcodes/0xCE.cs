namespace gbboi_emu
{
    public partial class Opcodes
    {
        /// <summary>
        /// ADC A,n
        /// Add 8-bit immediate and carry to A
        /// </summary>
        /// <param name="registers"></param>
        /// <param name="instruction"></param>
        public void _0xCE(Registers registers, Instruction instruction)
        {
            if((registers.A.Value >> 4) > (0xFF - (instruction.N) >> 8))
            {
                registers.F.CarryFlag = true;
            }

            registers.A.Value = (byte) (registers.A.Value + instruction.N);
        }
    }
}
