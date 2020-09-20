using System;

namespace gbboi_emu.Opcodes
{
    /// <summary>
    /// LD (HL),A
    /// </summary>
    [OneByteOpcode]
    public class _0x77 : IOpcode
    {
        public string Mnemonic { get; set; } = "LD (HL),A";

        public ushort Length { get; set; } = 1;

        public short Cycles { get; set; } = 8;

        public bool IncrementProgramCounter { get; set; } = true;

        public void Execute(Instruction instruction, ICpu cpu, IMmu mmu)
        {
            mmu.WriteByte(cpu.Registers.HL.Value, cpu.Registers.A.Value);
        }
    }
}
