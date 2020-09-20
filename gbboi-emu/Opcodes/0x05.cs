using System;

namespace gbboi_emu.Opcodes
{
    /// <summary>
    /// DEC B
    /// </summary>
    [OneByteOpcode]
    public class _0x05 : IOpcode
    {
        public string Mnemonic { get; set; } = "DEC B";

        public ushort Length { get; set; } = 1;

        public short Cycles { get; set; } = 4;

        public bool IncrementProgramCounter { get; set; } = true;

        public void Execute(Instruction instruction, ICpu cpu, IMmu mmu)
        {
            var originalValue = cpu.Registers.B.Value;
            cpu.Registers.B.Value--;

            cpu.Registers.F.ZeroFlag = cpu.Registers.B.Value == 0;
            cpu.Registers.F.SubtractFlag = false;

            // TODO: ???
            cpu.Registers.F.HalfCarryFlag = (((originalValue & 0xF) - (1 & 0xF)) & 0x10) == 0x10;
        }
    }
}
