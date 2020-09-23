using System;

namespace gbboi_emu.Opcodes
{
    /// <summary>
    /// LD E,n
    /// </summary>
    [OneByteOpcode]
    public class _0x1E : IOpcode
    {
        public string Mnemonic { get; set; } = "LD E,n";

        public ushort Length { get; set; } = 2;

        public short Cycles { get; set; } = 8;

        public bool IncrementProgramCounter { get; set; } = true;

        public void Execute(Instruction instruction, ICpu cpu, IMmu mmu)
        {
            cpu.Registers.E.Value = cpu.ReadImmediateN();
        }
    }
}
