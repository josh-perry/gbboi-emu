using System;

namespace gbboi_emu.Opcodes
{
    /// <summary>
    /// LD
    /// </summary>
    [OneByteOpcode]
    public class _0x1E : IOpcode
    {
        public string Mnemonic { get; set; } = "LD";

        public ushort Length { get; set; } = 2;

        public short Cycles { get; set; } = 8;

        public bool IncrementProgramCounter { get; set; } = true;

        public void Execute(Instruction instruction, ICpu cpu, IMemory memory)
        {
            cpu.Registers.E.Value = (byte)memory.ReadByte(cpu.Registers.PC.Value);
        }
    }
}
