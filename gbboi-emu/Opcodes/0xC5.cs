using System;

namespace gbboi_emu.Opcodes
{
    /// <summary>
    /// PUSH BC
    /// </summary>
    [OneByteOpcode]
    public class _0xC5 : IOpcode
    {
        public string Mnemonic { get; set; } = "PUSH BC";

        public ushort Length { get; set; } = 1;

        public short Cycles { get; set; } = 16;

        public bool IncrementProgramCounter { get; set; } = true;

        public void Execute(Instruction instruction, ICpu cpu, IMmu mmu)
        {
            cpu.Stack.Push(cpu.Registers.BC.Value, cpu.Registers, mmu);
        }
    }
}
