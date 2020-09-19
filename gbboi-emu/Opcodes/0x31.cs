namespace gbboi_emu.Opcodes
{
    /// <summary>
    /// LD SP,nn
    /// Load 16-bit immediate into SP
    /// </summary>
    [OneByteOpcode]
    public class _0x31 : IOpcode
    {
        public string Mnemonic { get; set; } = "LD SP,nn";

        public ushort Length { get; set; } = 3;

        public short Cycles { get; set; } = 1;

        public bool IncrementProgramCounter { get; set; } = true;

        public void Execute(Instruction instruction, ICpu cpu, IMemory memory)
        {
            cpu.Registers.SP.Value = memory.ReadWord((ushort)(cpu.Registers.PC.Value + 1));
        }
    }
}