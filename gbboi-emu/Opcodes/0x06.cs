using System;

namespace gbboi_emu.Opcodes
{
    /// <summary>
    /// LD B,n
    /// </summary>
    [OneByteOpcode]
    public class _0x06 : IOpcode
    {
        public string Mnemonic { get; set; } = "LD B,n";

        public ushort Length { get; set; } = 2;

        public short Cycles { get; set; } = 8;

        public bool IncrementProgramCounter { get; set; } = true;

        public void Execute(Instruction instruction, ICpu cpu, IMemory memory)
        {
            cpu.Registers.C.Value = memory.ReadByte(cpu.Registers.PC.Value);
        }
    }
}
