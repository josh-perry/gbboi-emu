namespace gbboi_emu
{
    public class Instruction
    {
        public ushort Opcode { get; set; }

        public Instruction(ushort opcode)
        {
            Opcode = opcode;
        }
    }
}
