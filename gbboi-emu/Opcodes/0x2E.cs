using System;

namespace gbboi_emu.Opcodes
{
    /// <summary>
    /// LD L, n
    /// </summary>
    [OneByteOpcode]
    public class _0x2E : IOpcode
    {
        public string Mnemonic { get; set; } = "LD L, n";

        public ushort Length { get; set; } = 2;

        public short Cycles { get; set; } = 8;

        public bool IncrementProgramCounter { get; set; } = true;

        public void Execute(Instruction instruction, ICpu cpu, IMmu mmu)
        {
            cpu.Registers.L.Value = cpu.ReadImmediateN(); 
        }
    }
}
