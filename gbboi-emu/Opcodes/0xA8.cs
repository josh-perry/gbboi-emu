using System;

namespace gbboi_emu.Opcodes
{
    /// <summary>
    /// XOR
    ///
    /// </summary>
    [OneByteOpcode]
    public class _0xA8 : IOpcode
    {
        public string Mnemonic { get; set; } = "XOR";

        public ushort Length { get; set; } = 1;

        public short Cycles { get; set; } = 4;

        public bool IncrementProgramCounter { get; set; } = true;

        public void Execute(Instruction instruction, ICpu cpu, IMmu mmu)
        {
            throw new NotImplementedException(Mnemonic);
        }
    }
}
