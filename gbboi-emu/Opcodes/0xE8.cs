using System;

namespace gbboi_emu.Opcodes
{
    /// <summary>
    /// ADD
    ///
    /// </summary>
    [OneByteOpcode]
    public class _0xE8 : IOpcode
    {
        public string Mnemonic { get; set; } = "ADD";

        public ushort Length { get; set; } = 2;

        public short Cycles { get; set; } = 16;

        public bool IncrementProgramCounter { get; set; } = true;

        public void Execute(Stack stack, Registers registers, Instruction instruction, IMemory memory)
        {
            throw new NotImplementedException(Mnemonic);
        }
    }
}