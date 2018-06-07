﻿namespace gbboi_emu.Opcodes
{
    /// <summary>
    /// LD HL,nn
    /// Load 16-bit immediate into HL
    /// </summary>
    public class _0x21 : IOpcode
    {
        public string Mnemonic { get; set; } = "LD HL,nn";

        public ushort Length { get; set; } = 3;

        public short Cycles { get; set; } = 1;

        public bool IncrementProgramCounter { get; set; } = true;

        public void Execute(Stack stack, Registers registers, Instruction instruction, IMemory memory)
        {
            registers.HL.Value = instruction.NN;
        }
    }
}
