namespace gbboi_emu.Opcodes
{
    /// <summary>
    /// XOR A
    /// Logical XOR A against A
    /// </summary>
    /// <param name="registers"></param>
    [OneByteOpcode]
    public class _0xAF : IOpcode
    {
        public string Mnemonic { get; set; } = "XOR A";

        public ushort Length { get; set; } = 1;

        public short Cycles { get; set; } = 1;

        public bool IncrementProgramCounter { get; set; } = true;

        public void Execute(Instruction instruction, ICpu cpu, IMmu mmu)
        {
            cpu.Registers.A.Value ^= cpu.Registers.A.Value;
        }
    }
}
