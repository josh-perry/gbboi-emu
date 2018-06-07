namespace gbboi_emu.Opcodes
{
    /// <summary>
    /// LD H,(HL)
    /// Copy value pointed by HL to H
    /// No operation
    /// </summary>
    public class _0x66 : IOpcode
    {
        public string Mnemonic { get; set; } = "LD H,(HL)";

        public short Length { get; set; } = 1;

        public short Cycles { get; set; } = 1;

        public void Execute(Stack stack, Registers registers, Instruction instruction, IMemory memory)
        {
            registers.H.Value = memory.Bytes[registers.HL.Value];

            registers.PC.Value += 1;
        }
    }
}
