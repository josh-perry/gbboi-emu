namespace gbboi_emu.Opcodes
{
    /// <summary>
    /// XOR A
    /// Logical XOR A against A
    /// </summary>
    /// <param name="registers"></param>
    public class _0xAF : IOpcode
    {
        public string Mnemonic { get; set; } = "XOR A";

        public ushort Length { get; set; } = 1;

        public short Cycles { get; set; } = 1;

        public bool IncrementProgramCounter { get; set; } = true;

        public void Execute(Stack stack, Registers registers, Instruction instruction, IMemory memory)
        {
            registers.A.Value ^= registers.A.Value;
        }
    }
}
