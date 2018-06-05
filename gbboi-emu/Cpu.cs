using System;
using System.Collections.Generic;
using gbboi_emu.Exceptions;

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
            var pc = Registers.PC.Value.ToString("x8");
            var op = "0x" + CurrentInstruction.Opcode.ToString("x4");
            Console.WriteLine($"{pc} {op}");

            switch (CurrentInstruction.Opcode & 0xFF00)
            {
                case 0x0000:
                    Opcodes._0x00(Registers);
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

                case 0xAF00:
                    Opcodes._0xAF(Registers);
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

                case 0xD300:
                case 0xDB00:
                case 0xDD00:
                case 0xE300:
                case 0xE400:
                case 0xEB00:
                case 0xEC00:
                case 0xED00:
                case 0xF200:
                case 0xF400:
                case 0xFC00:
                case 0xFD00:
                    throw new OperationNotSupportedByCpuException(CurrentInstruction.Opcode);

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
            //Registers.PC.Value += 2;
        }
    }
}