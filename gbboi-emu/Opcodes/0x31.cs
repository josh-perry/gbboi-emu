namespace gbboi_emu.Opcodes
{
    /// <summary>
    /// LD SP,nn
    /// Load 16-bit immediate into SP
    /// </summary>
    public class _0x31 : IOpcode
    {
        public string Mnemonic { get; set; } = "LD SP,nn";

        public ushort Length { get; set; } = 3;

        public short Cycles { get; set; } = 1;

        public bool IncrementProgramCounter { get; set; } = true;

        public void Execute(Stack stack, Registers registers, Instruction instruction, IMemory memory)
        {
            registers.SP.Value = instruction.NN;
        }
    }
}