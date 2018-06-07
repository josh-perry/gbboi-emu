namespace gbboi_emu.Opcodes
{
    /// <summary>
    /// RST 38
    /// Call routine at address 0038h
    /// </summary>
    public class _0xFF : IOpcode
    {
        public string Mnemonic { get; set; } = "RST 38";

        public short Length { get; set; } = 1;

        public short Cycles { get; set; } = 1;

        public void Execute(Stack stack, Registers registers, Instruction instruction, IMemory memory)
        {
            stack.Call(0x0038, registers, memory);
        }
    }
}
