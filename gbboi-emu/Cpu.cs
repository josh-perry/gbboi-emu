using System.Collections.Generic;

namespace gbboi_emu
{
    public class Cpu : ICpu
    {
        public IMemory Memory { get; set; }

        public Registers Registers { get; set; }

        public Instruction CurrentInstruction { get; set; }

        public Opcodes Opcodes { get; set; }

        public Stack Stack { get; set; }
        
        public Cpu(IMemory memory, Registers registers)
        {
            Memory = memory;
            Registers = registers;
            Opcodes = new Opcodes();
            Stack = new Stack();
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

                case 0x0100:
                    Opcodes._0x01(Registers, CurrentInstruction);
                    break;

                case 0x3100:
                    Opcodes._0x31(Registers, CurrentInstruction);
                    break;

                case 0x5000:
                    Opcodes._0x50(Registers);
                    break;

                case 0xCE00:
                    Opcodes._0xCE(Registers, CurrentInstruction);
                    break;

                case 0x6600:
                    Opcodes._0x66(Registers, Memory);
                    break;

                case 0xC300:
                    Opcodes._0xC3(Registers, CurrentInstruction);
                    break;

                case 0xCC00:
                    Opcodes._0xCC(Stack, Registers, CurrentInstruction, Memory);
                    break;

                case 0xFF00:
                    Opcodes._0xFF(Stack, Registers, Memory);
                    break;

                default:
                    throw new OpCodeNotSupportedException($"Opcode 0x{CurrentInstruction.Opcode.ToString("X4")} not supported!");
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