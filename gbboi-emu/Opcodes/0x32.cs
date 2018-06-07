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

        public short Length { get; set; } = 1;

        public short Cycles { get; set; } = 1;

        public void Execute(Stack stack, Registers registers, Instruction instruction, IMemory memory)
        {
            memory.Bytes[registers.HL.Value] = registers.A.Value;
            registers.HL.Value--;

            registers.PC.Value += 1;
        }
    }
}
