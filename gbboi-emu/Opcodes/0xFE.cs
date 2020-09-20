using System;

namespace gbboi_emu.Opcodes
{
    /// <summary>
    /// CP n
    /// </summary>
    [OneByteOpcode]
    public class _0xFE : IOpcode
    {
        public string Mnemonic { get; set; } = "CP n";

        public ushort Length { get; set; } = 2;

        public short Cycles { get; set; } = 8;

        public bool IncrementProgramCounter { get; set; } = true;

        public void Execute(Instruction instruction, ICpu cpu, IMmu mmu)
        {
            var n = cpu.ReadImmediateN();

            cpu.Registers.F.ZeroFlag = cpu.Registers.A.Value == n;
            cpu.Registers.F.CarryFlag = cpu.Registers.A.Value < n;
            cpu.Registers.F.SubtractFlag = true;
            
            // TODO: ???
            cpu.Registers.F.HalfCarryFlag = (((cpu.Registers.A.Value & 0xF) - (n & 0xF)) & 0x10) == 0x10;
        }
    }
}
