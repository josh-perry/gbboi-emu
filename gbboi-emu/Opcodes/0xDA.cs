using System;

namespace gbboi_emu.Opcodes
{
    /// <summary>
    /// JP
    ///
    /// </summary>
    [OneByteOpcode]
    public class _0xDA : IOpcode
    {
        public string Mnemonic { get; set; } = "JP";

        public ushort Length { get; set; } = 3;

        public short Cycles { get; set; } = 16;

        public bool IncrementProgramCounter { get; set; } = true;

        public void Execute(Instruction instruction, ICpu cpu, IMmu mmu)
        {
            throw new NotImplementedException(Mnemonic);
        }
    }
}
