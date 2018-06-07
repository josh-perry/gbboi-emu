﻿namespace gbboi_emu.Opcodes
{
    /// <summary>
    /// LD BC,nn
    /// Load 16-bit immediate into BC
    /// </summary>
    public class _0x01 : IOpcode
    {
        public string Mnemonic { get; set; } = "LD BC,nn";

        public ushort Length { get; set; } = 3;

        public short Cycles { get; set; } = 1;

        public bool IncrementProgramCounter { get; set; } = true;

        public void Execute(Stack stack, Registers registers, Instruction instruction, IMemory memory)
        {
            registers.BC.Value = instruction.NN;
        }
    }
}
