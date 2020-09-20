using System;

namespace gbboi_emu.Opcodes
{
    /// <summary>
    /// LD D,A
    /// </summary>
    [OneByteOpcode]
    public class _0x57 : IOpcode
    {
        public string Mnemonic { get; set; } = "LD D,A";

        public ushort Length { get; set; } = 1;

        public short Cycles { get; set; } = 4;

        public bool IncrementProgramCounter { get; set; } = true;

        public void Execute(Instruction instruction, ICpu cpu, IMmu mmu)
        {
            cpu.Registers.D.Value = cpu.Registers.A.Value;
        }
    }
}
