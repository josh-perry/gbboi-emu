namespace gbboi_emu
{
    public static partial class Opcodes
    {
        /// <summary>
        /// LD H,(HL)
        /// Copy value pointed by HL to H
        /// No operation
        /// </summary>
        public static void _0x66(Registers registers, IMemory memory)
        {
            registers.H.Value = memory.Bytes[registers.HL.Value];
        }
    }
}
