using System;

namespace gbboi_emu.Opcodes
{
    /// <summary>
    /// ADD A,(HL)
    /// </summary>
    [OneByteOpcode]
    public class _0x86 : IOpcode
    {
        public string Mnemonic { get; set; } = "ADD A,(HL)";

        public ushort Length { get; set; } = 1;

        public short Cycles { get; set; } = 8;

        public bool IncrementProgramCounter { get; set; } = true;

        public void Execute(Instruction instruction, ICpu cpu, IMmu mmu)
        {
            var originalValue = cpu.Registers.A.Value;

            cpu.Registers.A.Value += mmu.ReadByte(cpu.Registers.HL.Value);

            cpu.Registers.F.ZeroFlag = cpu.Registers.A.Value == 0;
            cpu.Registers.F.SubtractFlag = false;
            cpu.Registers.F.CarryFlag = cpu.Registers.A.Value <= mmu.ReadByte(cpu.Registers.HL.Value);

            // TODO: ???
            cpu.Registers.F.HalfCarryFlag = (((originalValue & 0xF) + (1 & 0xF)) & 0x10) == 0x10;
        }
    }
}
