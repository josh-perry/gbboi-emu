using System;

namespace gbboi_emu.Opcodes
{
    /// <summary>
    /// JR Z,n
    /// </summary>
    [OneByteOpcode]
    public class _0x28 : IOpcode
    {
        public string Mnemonic { get; set; } = "JR Z,n";

        public ushort Length { get; set; } = 2;

        public short Cycles { get; set; } = 12;

        public bool IncrementProgramCounter { get; set; } = true;

        public void Execute(Instruction instruction, ICpu cpu, IMmu mmu)
        {
            if (!cpu.Registers.F.ZeroFlag)
            {
                IncrementProgramCounter = true;
                return;
            }

            var b = (sbyte)cpu.ReadImmediateN();
            cpu.Registers.PC.Value += (ushort)b;
            IncrementProgramCounter = true;
        }
    }
}
