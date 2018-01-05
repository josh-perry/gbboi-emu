using System;

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

        public void DecodeInstruction()
        {
        }

        public void ExecuteInstruction()
        {
            switch (CurrentInstruction.Opcode & 0xFF00)
            {
                case 0x0000:
                    break;

                case 0x3100:
                    _0x31();
                    break;
            }
        }

        public void Cycle()
        {
            FetchInstruction();
            DecodeInstruction();
            ExecuteInstruction();
            IncrementProgramCounter();
        }
        
        private void IncrementProgramCounter()
        {
            Registers.PC.Value += 2;
        }

        /// <summary>
        /// Load 16-bit immediate into SP
        /// LD SP,nn
        /// </summary>
        private void _0x31()
        {
            Registers.SP.Value = CurrentInstruction.NN;
        }
    }
}