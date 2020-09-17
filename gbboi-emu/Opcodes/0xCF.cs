using System;

namespace gbboi_emu.Opcodes
{
    /// <summary>
    /// RST
    ///
    /// </summary>
    [OneByteOpcode]
    public class _0xCF : IOpcode
    {
        public string Mnemonic { get; set; } = "RST";

        public ushort Length { get; set; } = 1;

        public short Cycles { get; set; } = 16;

        public bool IncrementProgramCounter { get; set; } = true;

        public void Execute(Stack stack, Registers registers, Instruction instruction, IMemory memory)
        {
            throw new NotImplementedException(Mnemonic);
        }
    }
}
