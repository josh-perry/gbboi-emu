namespace gbboi_emu.Opcodes
{
    /// <summary>
    /// LD BC,nn
    /// Load 16-bit immediate into BC
    /// </summary>
    public class _0x01 : IOpcode
    {
        public short Length { get; set; } = 1;

        public short Cycles { get; set; } = 1;

        public void Execute(Stack stack, Registers registers, Instruction instruction, IMemory memory)
        {
            registers.BC.Value = instruction.NN;
            registers.PC.Value += 3;
        }
    }
}
