namespace gbboi_emu.Opcodes
{
    /// <summary>
    /// BIT 7,H
    /// Test bit 7 of H
    /// </summary>
    public class _0xCB7C : IOpcode
    {
        public string Mnemonic { get; set; } = "BIT 7,H";

        public ushort Length { get; set; } = 2;

        public short Cycles { get; set; } = 8;

        public bool IncrementProgramCounter { get; set; } = true;

        public void Execute(Instruction instruction, ICpu cpu, IMemory memory)
        {
            var mask = 1 << 7;
            cpu.Registers.F.ZeroFlag = (cpu.Registers.H.Value & mask) != mask;
            cpu.Registers.F.HalfCarryFlag = true;
            cpu.Registers.F.SubtractFlag = false;
        }
    }
}
