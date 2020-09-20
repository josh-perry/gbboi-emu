namespace gbboi_emu.Opcodes
{
    /// <summary>
    /// JP nn
    /// Absolute jump to 16-bit location
    /// </summary>
    [OneByteOpcode]
    public class _0xC3 : IOpcode
    {
        public string Mnemonic { get; set; } = "JP nn";

        public ushort Length { get; set; } = 1;

        public short Cycles { get; set; } = 1;

        public bool IncrementProgramCounter { get; set; } = false;

        public void Execute(Instruction instruction, ICpu cpu, IMmu mmu)
        {
            cpu.Registers.PC.Value = mmu.ReadWord((ushort)(cpu.Registers.PC.Value + 1));
        }
    }
}
