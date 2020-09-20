using System;

namespace gbboi_emu.Opcodes
{
    /// <summary>
    /// LDH A,(n)
    /// </summary>
    [OneByteOpcode]
    public class _0xF0 : IOpcode
    {
        public string Mnemonic { get; set; } = "LDH A,(n)";

        public ushort Length { get; set; } = 2;

        public short Cycles { get; set; } = 12;

        public bool IncrementProgramCounter { get; set; } = true;

        public void Execute(Instruction instruction, ICpu cpu, IMmu mmu)
        {
            var n = cpu.ReadImmediateN();
            cpu.Registers.A.Value = mmu.ReadByte((ushort)(0xFF00 + n));
        }
    }
}
