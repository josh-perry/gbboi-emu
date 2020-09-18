using System;

namespace gbboi_emu.Opcodes
{
    /// <summary>
    /// RET C
    /// </summary>
    [OneByteOpcode]
    public class _0xD8 : IOpcode
    {
        public string Mnemonic { get; set; } = "RET C";

        public ushort Length { get; set; } = 1;

        public short Cycles { get; set; } = 20;

        public bool IncrementProgramCounter { get; set; } = true;

        public void Execute(Instruction instruction, ICpu cpu, IMemory memory)
        {
            if (!cpu.Registers.F.CarryFlag) return;

            cpu.Stack.Return(cpu.Registers, memory);
        }
    }
}
