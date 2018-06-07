namespace gbboi_emu.Opcodes
{
    /// <summary>
    /// JP nn
    /// Absolute jump to 16-bit location
    /// </summary>
    public class _0xC3 : IOpcode
    {
        public short Length { get; set; } = 1;

        public short Cycles { get; set; } = 1;

        public void Execute(Stack stack, Registers registers, Instruction instruction, IMemory memory)
        {
            registers.PC.Value = instruction.NN;
        }
    }
}
