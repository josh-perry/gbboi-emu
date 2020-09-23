using System;

namespace gbboi_emu.Opcodes
{
    /// <summary>
    /// LD C,n
    /// </summary>
    [OneByteOpcode]
    public class _0x0E : IOpcode
    {
        public string Mnemonic { get; set; } = "LD C,n";

        public ushort Length { get; set; } = 2;

        public short Cycles { get; set; } = 8;

        public bool IncrementProgramCounter { get; set; } = true;

        public void Execute(Instruction instruction, ICpu cpu, IMmu mmu)
        {
            cpu.Registers.C.Value = cpu.ReadImmediateN();
        }
    }
}
