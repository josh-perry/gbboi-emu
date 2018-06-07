namespace gbboi_emu.Opcodes
{
    /// <summary>
    /// XOR A
    /// Logical XOR A against A
    /// </summary>
    /// <param name="registers"></param>
    public class _0xAF : IOpcode
    {
        public short Length { get; set; } = 1;

        public short Cycles { get; set; } = 1;

        public void Execute(Stack stack, Registers registers, Instruction instruction, IMemory memory)
        {
            registers.A.Value ^= registers.A.Value;
            registers.PC.Value += 1;
        }
    }
}
