using System;

namespace gbboi_emu.Opcodes
{
    /// <summary>
    /// RST
    ///
    /// </summary>
    [OneByteOpcode]
    public class _0xD7 : IOpcode
    {
        public string Mnemonic { get; set; } = "RST";

        public ushort Length { get; set; } = 1;

        public short Cycles { get; set; } = 16;

        public bool IncrementProgramCounter { get; set; } = true;

        public void Execute(Instruction instruction, ICpu cpu, IMmu mmu)
        {
            throw new NotImplementedException(Mnemonic);
        }
    }
}
