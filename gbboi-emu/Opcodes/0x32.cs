namespace gbboi_emu
{
    public partial class Opcodes
    {
        /// <summary>
        /// LDD (HL),A
        /// Save A to address pointed by HL, and decrement HL
        /// </summary>
        /// <param name="registers"></param>
        public void _0x32(Registers registers, IMemory memory)
        {
            memory.Bytes[registers.HL.Value] = registers.A.Value;
            registers.HL.Value--;

            registers.PC.Value += 1;
        }
    }
}
