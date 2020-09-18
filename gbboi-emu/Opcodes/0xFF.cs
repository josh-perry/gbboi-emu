namespace gbboi_emu.Opcodes
{
    /// <summary>
    /// RST 38
    /// Call routine at address 0038h
    /// </summary>
    [OneByteOpcode]
    public class _0xFF : IOpcode
    {
        public string Mnemonic { get; set; } = "RST 38";

        public ushort Length { get; set; } = 1;

        public short Cycles { get; set; } = 1;

        public bool IncrementProgramCounter { get; set; } = false;

        public void Execute(Instruction instruction, ICpu cpu, IMemory memory)
        {
            cpu.Stack.Call(0x0038, cpu.Registers, memory);
        }
    }
}
