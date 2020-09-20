using System;

namespace gbboi_emu.Opcodes
{
    /// <summary>
    /// SWAP
    ///
    /// </summary>
    [TwoByteOpcode]
    public class _0xCB34 : IOpcode
    {
        public string Mnemonic { get; set; } = "SWAP";

        public ushort Length { get; set; } = 2;

        public short Cycles { get; set; } = 8;

        public bool IncrementProgramCounter { get; set; } = true;

        public void Execute(Instruction instruction, ICpu cpu, IMmu mmu)
        {
            throw new NotImplementedException(Mnemonic);
        }
    }
}
