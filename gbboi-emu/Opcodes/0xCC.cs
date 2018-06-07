namespace gbboi_emu.Opcodes
{
    /// <summary>
    /// CALL Z,nn
    /// Call routine at 16-bit location if last result was zero
    /// </summary>
    /// <param name="registers"></param>
    /// <param name="instruction"></param>
    /// <param name="memory"></param>
    public class _0xCC : IOpcode
    {
        public short Length { get; set; } = 1;

        public short Cycles { get; set; } = 1;

        public void Execute(Stack stack, Registers registers, Instruction instruction, IMemory memory)
        {
            // Only call the routine if the zero flag is set
            if (!registers.F.ZeroFlag)
            {
                registers.PC.Value += 3;
                return;
            }

            stack.Call(instruction.NN, registers, memory);
        }
    }
}
