namespace gbboi_emu
{
    public partial class Opcodes
    {
        /// <summary>
        /// JP nn
        /// Absolute jump to 16-bit location
        /// </summary>
        public void _0xC3(Registers registers, Instruction currentInstruction)
        {
            registers.PC.Value = (ushort) (currentInstruction.NN - 2);
        }
    }
}
