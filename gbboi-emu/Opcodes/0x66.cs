namespace gbboi_emu.Opcodes
{
    /// <summary>
    /// LD H,(HL)
    /// Copy value pointed by HL to H
    /// </summary>
    [OneByteOpcode]
    public class _0x66 : IOpcode
    {
        public string Mnemonic { get; set; } = "LD H,(HL)";

        public ushort Length { get; set; } = 1;

        public short Cycles { get; set; } = 1;

        public bool IncrementProgramCounter { get; set; } = true;

        public void Execute(Stack stack, Registers registers, Instruction instruction, IMemory memory)
        {
            registers.H.Value = memory.Bytes[registers.HL.Value];
        }
    }
}
