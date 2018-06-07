namespace gbboi_emu.Opcodes
{
    /// <summary>
    /// LD D,B
    /// Copy B to D
    /// </summary>
    /// <param name="registers"></param>
    public class _0x50 : IOpcode
    {
        public short Length { get; set; } = 1;

        public short Cycles { get; set; } = 1;

        public void Execute(Stack stack, Registers registers, Instruction instruction, IMemory memory)
        {
            registers.D.Value = registers.B.Value;
            registers.PC.Value += 1;
        }
    }
}
