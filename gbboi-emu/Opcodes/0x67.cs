using System;

namespace gbboi_emu.Opcodes
{
    /// <summary>
    /// LD H,A
    /// </summary>
    [OneByteOpcode]
    public class _0x67 : IOpcode
    {
        public string Mnemonic { get; set; } = "LD H,A";

        public ushort Length { get; set; } = 1;

        public short Cycles { get; set; } = 4;

        public bool IncrementProgramCounter { get; set; } = true;

        public void Execute(Instruction instruction, ICpu cpu, IMemory memory)
        {
            cpu.Registers.H.Value = cpu.Registers.A.Value;
        }
    }
}
