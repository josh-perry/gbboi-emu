using System;

namespace gbboi_emu.Opcodes
{
    /// <summary>
    /// INC HL
    /// </summary>
    [OneByteOpcode]
    public class _0x23 : IOpcode
    {
        public string Mnemonic { get; set; } = "INC HL";

        public ushort Length { get; set; } = 1;

        public short Cycles { get; set; } = 8;

        public bool IncrementProgramCounter { get; set; } = true;

        public void Execute(Instruction instruction, ICpu cpu, IMemory memory)
        {
            var originalValue = cpu.Registers.HL.Value;
            cpu.Registers.HL.Value++;

            cpu.Registers.F.ZeroFlag = cpu.Registers.HL.Value == 0;
            cpu.Registers.F.SubtractFlag = false;
        }
    }
}
