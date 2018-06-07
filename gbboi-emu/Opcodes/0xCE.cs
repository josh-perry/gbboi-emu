namespace gbboi_emu.Opcodes
{
    /// <summary>
    /// ADC A,n
    /// Add 8-bit immediate and carry to A
    /// </summary>
    /// <param name="registers"></param>
    /// <param name="instruction"></param>
    public class _0xCE : IOpcode
    {
        public short Length { get; set; } = 1;

        public short Cycles { get; set; } = 1;

        public void Execute(Stack stack, Registers registers, Instruction instruction, IMemory memory)
        {
            var originalValue = registers.A.Value;

            registers.A.Value = (byte) (registers.A.Value + instruction.N);

            // Flags
            registers.F.SubtractFlag = false;
            registers.F.CarryFlag = originalValue + instruction.N > byte.MaxValue;
            registers.F.ZeroFlag = registers.A.Value == 0;
            registers.F.HalfCarryFlag = (((originalValue & 0xF) + (instruction.N & 0xF)) & 0x10) == 0x10;

            registers.PC.Value += 2;
        }
    }
}
