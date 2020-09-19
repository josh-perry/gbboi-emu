using System;

namespace gbboi_emu.Opcodes
{
    /// <summary>
    /// SUB A,B
    /// </summary>
    [OneByteOpcode]
    public class _0x90 : IOpcode
    {
        public string Mnemonic { get; set; } = "SUB A,B";

        public ushort Length { get; set; } = 1;

        public short Cycles { get; set; } = 4;

        public bool IncrementProgramCounter { get; set; } = true;

        public void Execute(Instruction instruction, ICpu cpu, IMemory memory)
        {
            var originalValue = cpu.Registers.A.Value;
            cpu.Registers.A.Value -= cpu.Registers.B.Value;

            cpu.Registers.F.ZeroFlag = cpu.Registers.A.Value == 0;
            cpu.Registers.F.SubtractFlag = true;
            cpu.Registers.F.CarryFlag = cpu.Registers.A.Value < cpu.Registers.B.Value;

            // TODO: ???
            cpu.Registers.F.HalfCarryFlag = (((originalValue & 0xF) - (1 & 0xF)) & 0x10) == 0x10;
        }
    }
}
