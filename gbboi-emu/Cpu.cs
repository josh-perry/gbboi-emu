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

        public OpExecutor OpExecutor { get; set; }

        public Stack Stack { get; set; }
        
        public Cpu(IMemory memory, Registers registers)
        {
            Memory = memory;
            Registers = registers;
            Stack = new Stack();
            OpExecutor = new OpExecutor();
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

            var maskedOpcode = CurrentInstruction.Opcode & 0xFF00;

            if (!OpExecutor.Ops.ContainsKey(maskedOpcode))
            {
                throw new OpCodeNotSupportedException($"Opcode 0x{CurrentInstruction.Opcode.ToString("X4")} not supported!");
            }

            OpExecutor.Ops[maskedOpcode](Stack, Registers, CurrentInstruction, Memory);
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