using System;

namespace gbboi_emu.Opcodes
{
    /// <summary>
    /// LDI (HL),A
    /// </summary>
    [OneByteOpcode]
    public class _0x22 : IOpcode
    {
        public string Mnemonic { get; set; } = "LDI (HL),A";

        public ushort Length { get; set; } = 1;

        public short Cycles { get; set; } = 8;

        public bool IncrementProgramCounter { get; set; } = true;

        public void Execute(Instruction instruction, ICpu cpu, IMemory memory)
        {
            memory.Bytes[cpu.Registers.HL.Value] = cpu.Registers.A.Value;
            cpu.Registers.HL.Value++;
        }
    }
}
