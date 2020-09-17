using System;

namespace gbboi_emu.Opcodes
{
    /// <summary>
    /// POP
    ///
    /// </summary>
    [OneByteOpcode]
    public class _0xC1 : IOpcode
    {
        public string Mnemonic { get; set; } = "POP";

        public ushort Length { get; set; } = 1;

        public short Cycles { get; set; } = 12;

        public bool IncrementProgramCounter { get; set; } = true;

        public void Execute(Stack stack, Registers registers, Instruction instruction, IMemory memory)
        {
            throw new NotImplementedException(Mnemonic);
        }
    }
}