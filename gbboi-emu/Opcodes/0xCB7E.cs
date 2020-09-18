using System;

namespace gbboi_emu.Opcodes
{
    /// <summary>
    /// BIT
    ///
    /// </summary>
    [TwoByteOpcode]
    public class _0xCB7E : IOpcode
    {
        public string Mnemonic { get; set; } = "BIT";

        public ushort Length { get; set; } = 2;

        public short Cycles { get; set; } = 16;

        public bool IncrementProgramCounter { get; set; } = true;

        public void Execute(Instruction instruction, ICpu cpu, IMemory memory)
        {
            throw new NotImplementedException(Mnemonic);
        }
    }
}
