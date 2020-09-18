using System;

namespace gbboi_emu.Opcodes
{
    /// <summary>
    /// CALL Z,nn
    /// </summary>
    [OneByteOpcode]
    public class _0xCD : IOpcode
    {
        public string Mnemonic { get; set; } = "CALL Z,nn";

        public ushort Length { get; set; } = 3;

        public short Cycles { get; set; } = 24;

        public bool IncrementProgramCounter { get; set; } = true;

        public void Execute(Instruction instruction, ICpu cpu, IMemory memory)
        {
            if(!cpu.Registers.F.ZeroFlag)
            {
                return;
            }

            cpu.Stack.Call(instruction.NN, cpu.Registers, memory);
        }
    }
}
