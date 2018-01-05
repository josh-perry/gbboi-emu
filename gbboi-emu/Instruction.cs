namespace gbboi_emu
{
    public class Instruction
    {
        public ushort Opcode { get; set; }

        public ushort NNN => (ushort)(Opcode & 0x0FFF);

        public ushort NN => (ushort)(Opcode & 0x00FF);

        public ushort N => (ushort)(Opcode & 0x000F);

        public Instruction(ushort opcode)
        {
            Opcode = opcode;
        }
    }
}
