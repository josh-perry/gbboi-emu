using System;

namespace gbboi_emu.Opcodes
{
    /// <summary>
    /// LD (nn),A
    /// </summary>
    [OneByteOpcode]
    public class _0xEA : IOpcode
    {
        public string Mnemonic { get; set; } = "LD (nn),A";

        public ushort Length { get; set; } = 3;

        public short Cycles { get; set; } = 16;

        public bool IncrementProgramCounter { get; set; } = true;

        public void Execute(Instruction instruction, ICpu cpu, IMemory memory)
        {
            var nn = cpu.ReadImmediateNN();
            memory.Bytes[nn] = cpu.Registers.A.Value;
        }
    }
}
