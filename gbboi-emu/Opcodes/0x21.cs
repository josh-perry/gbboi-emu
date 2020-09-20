namespace gbboi_emu.Opcodes
{
    /// <summary>
    /// LD HL,nn
    /// Load 16-bit immediate into HL
    /// </summary>
    [OneByteOpcode]
    public class _0x21 : IOpcode
    {
        public string Mnemonic { get; set; } = "LD HL,nn";

        public ushort Length { get; set; } = 3;

        public short Cycles { get; set; } = 1;

        public bool IncrementProgramCounter { get; set; } = true;

        public void Execute(Instruction instruction, ICpu cpu, IMmu mmu)
        {
            cpu.Registers.HL.Value = mmu.ReadWord((ushort)(cpu.Registers.PC.Value + 1));
        }
    }
}
