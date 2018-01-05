namespace gbboi_emu
{
    public class Cpu : ICpu
    {
        public IMemory Memory { get; set; }

        public Registers Registers { get; set; }

        public Instruction CurrentInstruction { get; set; }

        public Cpu(IMemory memory, Registers registers)
        {
            Memory = memory;
            Registers = registers;
        }

        public void FetchInstruction()
        {
            var op = (ushort) ((Memory.Bytes[Registers.PC.Value] << 8) | Memory.Bytes[Registers.PC.Value + 1]);
            CurrentInstruction = new Instruction(op);
        }

        public void ExecuteInstruction()
        {
            switch (CurrentInstruction.Opcode & 0xFF00)
            {
                case 0x0000:
                    Opcodes._0x00();
                    break;

                case 0x3100:
                    Opcodes._0x31(Registers, CurrentInstruction);
                    break;

                case 0x5000:
                    Opcodes._0x50(Registers);
                    break;

                default:
                    throw new OpCodeNotSupportedException();
            }
        }

        public void Cycle()
        {
            FetchInstruction();
            ExecuteInstruction();
            IncrementProgramCounter();
        }
        
        private void IncrementProgramCounter()
        {
            Registers.PC.Value += 2;
        }
    }
}