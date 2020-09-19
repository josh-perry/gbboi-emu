using System;

namespace gbboi_emu.Opcodes
{
    /// <summary>
    /// LD A,H
    /// </summary>
    [OneByteOpcode]
    public class _0x7C : IOpcode
    {
        public string Mnemonic { get; set; } = "LD A,H";

        public ushort Length { get; set; } = 1;

        public short Cycles { get; set; } = 4;

        public bool IncrementProgramCounter { get; set; } = true;

        public void Execute(Instruction instruction, ICpu cpu, IMemory memory)
        {
            cpu.Registers.A.Value = cpu.Registers.H.Value;
        }
    }
}
