using System;

namespace gbboi_emu.Opcodes
{
    /// <summary>
    /// LDH (n),A
    /// </summary>
    [OneByteOpcode]
    public class _0xE0 : IOpcode
    {
        public string Mnemonic { get; set; } = "LDH (n),A";

        public ushort Length { get; set; } = 2;

        public short Cycles { get; set; } = 12;

        public bool IncrementProgramCounter { get; set; } = true;

        public void Execute(Instruction instruction, ICpu cpu, IMemory memory)
        {
            memory.Bytes[0xFF00 + memory.ReadByte((ushort)(cpu.Registers.PC.Value + 1))] = cpu.Registers.A.Value;
        }
    }
}
