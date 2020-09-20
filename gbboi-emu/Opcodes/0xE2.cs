using System;

namespace gbboi_emu.Opcodes
{
    /// <summary>
    /// LDH (C),A
    /// </summary>
    [OneByteOpcode]
    public class _0xE2 : IOpcode
    {
        public string Mnemonic { get; set; } = "LDH (C),A";

        public ushort Length { get; set; } = 1;

        public short Cycles { get; set; } = 8;

        public bool IncrementProgramCounter { get; set; } = true;

        public void Execute(Instruction instruction, ICpu cpu, IMmu mmu)
        {
            mmu.WriteByte((ushort)(0xFF00 + cpu.Registers.C.Value), cpu.Registers.A.Value);
        }
    }
}
