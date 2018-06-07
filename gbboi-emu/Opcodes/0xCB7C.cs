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

        public void Execute(Stack stack, Registers registers, Instruction instruction, IMemory memory)
        {
            var mask = 1 << 7;
            registers.F.ZeroFlag = (registers.H.Value & mask) != mask;
            registers.F.HalfCarryFlag = true;
            registers.F.SubtractFlag = false;
        }
    }
}
