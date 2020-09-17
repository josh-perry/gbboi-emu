using System;

namespace gbboi_emu.Opcodes
{
    /// <summary>
    /// BIT
    ///
    /// </summary>
    [TwoByteOpcode]
    public class _0xCB74 : IOpcode
    {
        public string Mnemonic { get; set; } = "BIT";

        public ushort Length { get; set; } = 2;

        public short Cycles { get; set; } = 8;

        public bool IncrementProgramCounter { get; set; } = true;

        public void Execute(Stack stack, Registers registers, Instruction instruction, IMemory memory)
        {
            throw new NotImplementedException(Mnemonic);
        }
    }
}
