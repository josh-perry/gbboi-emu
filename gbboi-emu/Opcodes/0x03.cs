using System;

namespace gbboi_emu.Opcodes
{
    /// <summary>
    /// INC BC
    /// </summary>
    [OneByteOpcode]
    public class _0x03 : IOpcode
    {
        public string Mnemonic { get; set; } = "INC BC";

        public ushort Length { get; set; } = 1;

        public short Cycles { get; set; } = 8;

        public bool IncrementProgramCounter { get; set; } = true;

        public void Execute(Instruction instruction, ICpu cpu, IMemory memory)
        {
            var originalValue = cpu.Registers.BC.Value;
            cpu.Registers.BC.Value++;

            cpu.Registers.F.ZeroFlag = cpu.Registers.BC.Value == 0;
            cpu.Registers.F.SubtractFlag = false;

            // TODO: ???
            cpu.Registers.F.HalfCarryFlag = (((originalValue & 0xF) + (1 & 0xF)) & 0x10) == 0x10;
        }
    }
}
