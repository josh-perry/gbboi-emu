namespace gbboi_emu.Opcodes
{
    /// <summary>
    /// ADC A,n
    /// Add 8-bit immediate and carry to A
    /// </summary>
    /// <param name="registers"></param>
    /// <param name="instruction"></param>
    [OneByteOpcode]
    public class _0xCE : IOpcode
    {
        public string Mnemonic { get; set; } = "ADC A,n";

        public ushort Length { get; set; } = 2;

        public short Cycles { get; set; } = 1;

        public bool IncrementProgramCounter { get; set; } = true;

        public void Execute(Instruction instruction, ICpu cpu, IMemory memory)
        {
            var originalValue = cpu.Registers.A.Value;

            cpu.Registers.A.Value = (byte) (cpu.Registers.A.Value + instruction.N);

            // Flags
            cpu.Registers.F.SubtractFlag = false;
            cpu.Registers.F.CarryFlag = originalValue + instruction.N > byte.MaxValue;
            cpu.Registers.F.ZeroFlag = cpu.Registers.A.Value == 0;
            cpu.Registers.F.HalfCarryFlag = (((originalValue & 0xF) + (instruction.N & 0xF)) & 0x10) == 0x10;
        }
    }
}
