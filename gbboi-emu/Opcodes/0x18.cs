using System;

namespace gbboi_emu.Opcodes
{
    /// <summary>
    /// JR n
    /// </summary>
    [OneByteOpcode]
    public class _0x18 : IOpcode
    {
        public string Mnemonic { get; set; } = "JR n";

        public ushort Length { get; set; } = 2;

        public short Cycles { get; set; } = 12;

        public bool IncrementProgramCounter { get; set; } = true;

        public void Execute(Instruction instruction, ICpu cpu, IMmu mmu)
        {
            var b = (sbyte)cpu.ReadImmediateN();
            cpu.Registers.PC.Value += (ushort)b;
        }
    }
}
