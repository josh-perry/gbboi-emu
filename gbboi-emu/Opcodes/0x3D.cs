using System;

namespace gbboi_emu.Opcodes
{
    /// <summary>
    /// DEC A
    /// </summary>
    [OneByteOpcode]
    public class _0x3D : IOpcode
    {
        public string Mnemonic { get; set; } = "DEC A";

        public ushort Length { get; set; } = 1;

        public short Cycles { get; set; } = 4;

        public bool IncrementProgramCounter { get; set; } = true;

        public void Execute(Instruction instruction, ICpu cpu, IMmu mmu)
        {
            var originalValue = cpu.Registers.A.Value;
            cpu.Registers.A.Value--;

            cpu.Registers.F.ZeroFlag = cpu.Registers.A.Value == 0;
            cpu.Registers.F.SubtractFlag = true;

            // TODO: ???
            cpu.Registers.F.HalfCarryFlag = (((originalValue & 0xF) + (1 & 0xF)) & 0x10) == 0x10;
        }
    }
}
