namespace gbboi_emu
{
    public partial class Opcodes
    {
        /// <summary>
        /// LD HL,nn
        /// Load 16-bit immediate into HL
        /// </summary>
        public void _0x21(Registers registers, Instruction currentInstruction)
        {
            registers.HL.Value = currentInstruction.NN;
            registers.PC.Value += 3;
        }
    }
}
