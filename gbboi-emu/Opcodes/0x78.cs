using System;

namespace gbboi_emu.Opcodes
{
    /// <summary>
    /// LD A,B
    /// </summary>
    [OneByteOpcode]
    public class _0x78 : IOpcode
    {
        public string Mnemonic { get; set; } = "LD A,B";

        public ushort Length { get; set; } = 1;

        public short Cycles { get; set; } = 4;

        public bool IncrementProgramCounter { get; set; } = true;

        public void Execute(Instruction instruction, ICpu cpu, IMmu mmu)
        {
            cpu.Registers.A.Value = cpu.Registers.B.Value;
        }
    }
}
