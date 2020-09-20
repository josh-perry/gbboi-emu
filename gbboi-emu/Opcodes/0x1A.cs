using System;

namespace gbboi_emu.Opcodes
{
    /// <summary>
    /// LD A,(DE)
    /// </summary>
    [OneByteOpcode]
    public class _0x1A : IOpcode
    {
        public string Mnemonic { get; set; } = "LD A,(DE)";

        public ushort Length { get; set; } = 1;

        public short Cycles { get; set; } = 8;

        public bool IncrementProgramCounter { get; set; } = true;

        public void Execute(Instruction instruction, ICpu cpu, IMmu mmu)
        {
            cpu.Registers.A.Value = mmu.ReadByte(cpu.Registers.DE.Value);
        }
    }
}
