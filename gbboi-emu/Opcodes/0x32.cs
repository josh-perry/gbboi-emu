namespace gbboi_emu.Opcodes
{
    /// <summary>
    /// LDD (HL),A
    /// Save A to address pointed by HL, and decrement HL
    /// </summary>
    /// <param name="registers"></param>
    public class _0x32 : IOpcode
    {
        public string Mnemonic { get; set; } = "LDD (HL),A";

        public ushort Length { get; set; } = 1;

        public short Cycles { get; set; } = 1;

        public bool IncrementProgramCounter { get; set; } = true;

        public void Execute(Instruction instruction, ICpu cpu, IMmu mmu)
        {
            mmu.WriteByte(cpu.Registers.HL.Value, cpu.Registers.A.Value);
            cpu.Registers.HL.Value--;
        }
    }
}
