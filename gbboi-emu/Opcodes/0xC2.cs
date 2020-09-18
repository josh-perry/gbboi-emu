using System;

namespace gbboi_emu.Opcodes
{
    /// <summary>
    /// JP
    ///
    /// </summary>
    [OneByteOpcode]
    public class _0xC2 : IOpcode
    {
        public string Mnemonic { get; set; } = "JP";

        public ushort Length { get; set; } = 3;

        public short Cycles { get; set; } = 16;

        public bool IncrementProgramCounter { get; set; } = true;

        public void Execute(Instruction instruction, ICpu cpu, IMemory memory)
        {
            throw new NotImplementedException(Mnemonic);
        }
    }
}
