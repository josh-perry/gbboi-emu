namespace gbboi_emu.Opcodes
{
    /// <summary>
    /// CALL Z,nn
    /// Call routine at 16-bit location if last result was zero
    /// </summary>
    /// <param name="registers"></param>
    /// <param name="instruction"></param>
    /// <param name="memory"></param>
    [OneByteOpcode]
    public class _0xCC : IOpcode
    {
        public string Mnemonic { get; set; } = "CALL Z,nn";

        public ushort Length { get; set; } = 3;

        public short Cycles { get; set; } = 1;

        public bool IncrementProgramCounter { get; set; } = true;

        public void Execute(Instruction instruction, ICpu cpu, IMemory memory)
        {
            // Only call the routine if the zero flag is set
            if (!cpu.Registers.F.ZeroFlag)
            {
                IncrementProgramCounter = true;
                return;
            }

            cpu.Stack.Call(instruction.NN, cpu.Registers, memory);
            IncrementProgramCounter = false;
        }
    }
}
