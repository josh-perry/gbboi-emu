namespace gbboi_emu.Opcodes
{
    /// <summary>
    /// RLC A
    /// </summary>
    [OneByteOpcode]
    public class _0x07 : IOpcode
    {
        public string Mnemonic { get; set; } = "RLC A";

        public ushort Length { get; set; } = 1;

        public short Cycles { get; set; } = 4;

        public bool IncrementProgramCounter { get; set; } = true;

        public void Execute(Instruction instruction, ICpu cpu, IMemory memory)
        {
            if ((cpu.Registers.A.Value & 0x80) != 0)
            {
                cpu.Registers.A.Value = (byte)((cpu.Registers.A.Value << 1) | 0x01);
                cpu.Registers.F.CarryFlag = true;
            }
            else
            {
                cpu.Registers.A.Value <<= 1;
                cpu.Registers.F.CarryFlag = true;
            }

            cpu.Registers.F.ZeroFlag = false;
            cpu.Registers.F.SubtractFlag = false;
            cpu.Registers.F.HalfCarryFlag = false;
        }
    }
}
