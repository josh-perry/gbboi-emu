using System;

namespace gbboi_emu.Opcodes
{
    /// <summary>
    /// INC C
    /// </summary>
    [OneByteOpcode]
    public class _0x0C : IOpcode
    {
        public string Mnemonic { get; set; } = "INC C";

        public ushort Length { get; set; } = 1;

        public short Cycles { get; set; } = 4;

        public bool IncrementProgramCounter { get; set; } = true;

        public void Execute(Instruction instruction, ICpu cpu, IMemory memory)
        {
            var originalValue = cpu.Registers.C.Value;
            cpu.Registers.C.Value++;

            cpu.Registers.F.ZeroFlag = cpu.Registers.C.Value == 0;
            cpu.Registers.F.SubtractFlag = false;

            // TODO: ???
            cpu.Registers.F.HalfCarryFlag = (((originalValue & 0xF) + (1 & 0xF)) & 0x10) == 0x10;
        }
    }
}
