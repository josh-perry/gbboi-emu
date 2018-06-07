namespace gbboi_emu.Opcodes
{
    /// <summary>
    /// LD SP,nn
    /// Load 16-bit immediate into SP
    /// </summary>
    public class _0x31 : IOpcode
    {
        public short Length { get; set; } = 1;

        public short Cycles { get; set; } = 1;

        public void Execute(Stack stack, Registers registers, Instruction instruction, IMemory memory)
        {
            registers.SP.Value = instruction.NN;
            registers.PC.Value += 3;
        }
    }
}