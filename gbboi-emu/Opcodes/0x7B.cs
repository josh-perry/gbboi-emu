using System;

namespace gbboi_emu.Opcodes
{
    /// <summary>
    /// LD A,E
    /// </summary>
    [OneByteOpcode]
    public class _0x7B : IOpcode
    {
        public string Mnemonic { get; set; } = "LD A,E";

        public ushort Length { get; set; } = 1;

        public short Cycles { get; set; } = 4;

        public bool IncrementProgramCounter { get; set; } = true;

        public void Execute(Instruction instruction, ICpu cpu, IMmu mmu)
        {
            cpu.Registers.A.Value = cpu.Registers.E.Value;
        }
    }
}
