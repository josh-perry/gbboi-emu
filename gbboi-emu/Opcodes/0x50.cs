namespace gbboi_emu.Opcodes
{
    /// <summary>
    /// LD D,B
    /// Copy B to D
    /// </summary>
    /// <param name="registers"></param>
    [OneByteOpcode]
    public class _0x50 : IOpcode
    {
        public string Mnemonic { get; set; } = "LD D,B";

        public ushort Length { get; set; } = 1;

        public short Cycles { get; set; } = 1;

        public bool IncrementProgramCounter { get; set; } = true;

        public void Execute(Stack stack, Registers registers, Instruction instruction, IMemory memory)
        {
            registers.D.Value = registers.B.Value;
        }
    }
}
