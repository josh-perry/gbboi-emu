namespace gbboi_emu
{
    public partial class Opcodes
    {
        /// <summary>
        /// LD BC,nn
        /// Load 16-bit immediate into BC
        /// </summary>
        public void _0x01(Registers registers, Instruction currentInstruction)
        {
            registers.BC.Value = currentInstruction.NN;
            registers.PC.Value += 3;
        }
    }
}
