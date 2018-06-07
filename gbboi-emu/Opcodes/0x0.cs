namespace gbboi_emu.Opcodes
{
    /// <summary>
    /// NOP
    /// No operation
    /// </summary>
    public class _0x00 : IOpcode
    {
        public string Mnemonic { get; set; } = "NOP";

        public short Length { get; set; } = 1;

        public short Cycles { get; set; } = 1;

        public void Execute(Stack stack, Registers registers, Instruction instruction, IMemory memory)
        {
            registers.PC.Value += 1;
        }
    }
}
