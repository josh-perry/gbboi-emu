namespace gbboi_emu.Opcodes
{
    /// <summary>
    /// LD HL,nn
    /// Load 16-bit immediate into HL
    /// </summary>
    public class _0x21 : IOpcode
    {
        public short Length { get; set; } = 1;

        public short Cycles { get; set; } = 1;

        public void Execute(Stack stack, Registers registers, Instruction instruction, IMemory memory)
        {
            registers.HL.Value = instruction.NN;
            registers.PC.Value += 3;
        }
    }
}
