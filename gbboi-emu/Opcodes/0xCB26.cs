using System;

namespace gbboi_emu.Opcodes
{
    /// <summary>
    /// SLA
    ///
    /// </summary>
    [TwoByteOpcode]
    public class _0xCB26 : IOpcode
    {
        public string Mnemonic { get; set; } = "SLA";

        public ushort Length { get; set; } = 2;

        public short Cycles { get; set; } = 16;

        public bool IncrementProgramCounter { get; set; } = true;

        public void Execute(Stack stack, Registers registers, Instruction instruction, IMemory memory)
        {
            throw new NotImplementedException(Mnemonic);
        }
    }
}
