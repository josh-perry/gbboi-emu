namespace gbboi_emu.Opcodes
{
    /// <summary>
    /// JR NZ,n
    /// Relative jump by signed immediate if last result was not zero
    /// </summary>
    [OneByteOpcode]
    public class _0x20 : IOpcode
    {
        public string Mnemonic { get; set; } = "JR NZ,n";

        public ushort Length { get; set; } = 1;

        public short Cycles { get; set; } = 1;

        public bool IncrementProgramCounter { get; set; } = true;

        public void Execute(Instruction instruction, ICpu cpu, IMemory memory)
        {
            if (cpu.Registers.F.ZeroFlag)
            {
                IncrementProgramCounter = true;
                return;
            }

            cpu.Registers.PC.Value += instruction.N;
            IncrementProgramCounter = false;
        }
    }
}
