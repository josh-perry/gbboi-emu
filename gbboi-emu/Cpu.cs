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

        public IOpcode CurrentOpcode { get; set; }

        public OpExecutor OpExecutor { get; set; }

        public Stack Stack { get; set; }

        public bool InterruptsEnabled { get; set; }
        
        public Cpu(IMemory memory, Registers registers)
        {
            InterruptsEnabled = false;
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
            var maskedOpcode = CurrentInstruction.Opcode & 0xFF00;

            if (!OpExecutor.Ops.ContainsKey(maskedOpcode) && !OpExecutor.ExtendedOps.ContainsKey(CurrentInstruction.Opcode))
            {
                throw new OpCodeNotSupportedException($"Opcode 0x{CurrentInstruction.Opcode.ToString("X4")} not supported!");
            }

            if (maskedOpcode == 0xCB00)
            {
                CurrentOpcode = OpExecutor.ExtendedOps[CurrentInstruction.Opcode];
            }
            else
            {
                CurrentOpcode = OpExecutor.Ops[maskedOpcode];
            }

            var pc = Registers.PC.Value.ToString("x8");
            Console.WriteLine($"{pc} {CurrentOpcode.Mnemonic}");

            CurrentOpcode.Execute(CurrentInstruction, this, Memory);
        }
        
        public void Cycle()
        {
            FetchInstruction();
            ExecuteInstruction();
            IncrementProgramCounter();
        }
        
        private void IncrementProgramCounter()
        {
            if (!CurrentOpcode.IncrementProgramCounter)
            {
                return;
            }

            Registers.PC.Value += CurrentOpcode.Length;
        }
    }
}