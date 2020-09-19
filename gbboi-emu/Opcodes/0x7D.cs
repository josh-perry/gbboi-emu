using System;

namespace gbboi_emu.Opcodes
{
    /// <summary>
    /// LD A,L
    /// </summary>
    [OneByteOpcode]
    public class _0x7D : IOpcode
    {
        public string Mnemonic { get; set; } = "LD A,L";

        public ushort Length { get; set; } = 1;

        public short Cycles { get; set; } = 4;

        public bool IncrementProgramCounter { get; set; } = true;

        public void Execute(Instruction instruction, ICpu cpu, IMemory memory)
        {
            cpu.Registers.A.Value = cpu.Registers.L.Value;
        }
    }
}
