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

        public void Execute(Stack stack, Registers registers, Instruction instruction, IMemory memory)
        {
            if (registers.F.ZeroFlag)
            {
                IncrementProgramCounter = true;
                return;
            }

            registers.PC.Value += instruction.N;
            IncrementProgramCounter = false;
        }
    }
}
