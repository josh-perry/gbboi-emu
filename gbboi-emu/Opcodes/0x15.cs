using System;

namespace gbboi_emu.Opcodes
{
    /// <summary>
    /// DEC D
    /// </summary>
    [OneByteOpcode]
    public class _0x15 : IOpcode
    {
        public string Mnemonic { get; set; } = "DEC D";

        public ushort Length { get; set; } = 1;

        public short Cycles { get; set; } = 4;

        public bool IncrementProgramCounter { get; set; } = true;


        public void Execute(Instruction instruction, ICpu cpu, IMemory memory)
        {
            var originalValue = cpu.Registers.D.Value;
            cpu.Registers.D.Value--;

            cpu.Registers.F.ZeroFlag = cpu.Registers.D.Value == 0;
            cpu.Registers.F.SubtractFlag = false;

            // TODO: ???
            cpu.Registers.F.HalfCarryFlag = (((originalValue & 0xF) - (1 & 0xF)) & 0x10) == 0x10;
        }
    }
}
