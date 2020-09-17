using System;

namespace gbboi_emu.Opcodes
{
    /// <summary>
    /// INC
    ///
    /// </summary>
    [OneByteOpcode]
    public class _0x14 : IOpcode
    {
        public string Mnemonic { get; set; } = "INC";

        public ushort Length { get; set; } = 1;

        public short Cycles { get; set; } = 4;

        public bool IncrementProgramCounter { get; set; } = true;

        public void Execute(Stack stack, Registers registers, Instruction instruction, IMemory memory)
        {
            throw new NotImplementedException(Mnemonic);
        }
    }
}
