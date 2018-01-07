namespace gbboi_emu
{
    public partial class Opcodes
    {
        /// <summary>
        /// CALL Z,nn
        /// Call routine at 16-bit location if last result was zero
        /// </summary>
        /// <param name="registers"></param>
        /// <param name="instruction"></param>
        /// <param name="memory"></param>
        public void _0xCC(Registers registers, Instruction instruction, IMemory memory)
        {
            // Only call the routine if the zero flag is set
            if (!registers.F.ZeroFlag)
            {
                return;
            }

            // Decrement the SP
            // TODO: Stop skipping the first 2 bytes of the stack
            registers.SP.Value -= 2;

            // Add current PC to the stack
            memory.Bytes[registers.SP.Value] = registers.PC.Registers[0].Value;
            memory.Bytes[registers.SP.Value + 1] = registers.PC.Registers[1].Value;

            // Set SP to nn
            registers.PC.Value = instruction.NN;
        }
    }
}
