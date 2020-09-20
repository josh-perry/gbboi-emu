using System;

namespace gbboi_emu.Opcodes
{
    /// <summary>
    /// LD
    ///
    /// </summary>
    [OneByteOpcode]
    public class _0x08 : IOpcode
    {
        public string Mnemonic { get; set; } = "LD";

        public ushort Length { get; set; } = 3;

        public short Cycles { get; set; } = 20;

        public bool IncrementProgramCounter { get; set; } = true;

        public void Execute(Instruction instruction, ICpu cpu, IMmu mmu)
        {
            throw new NotImplementedException(Mnemonic);
        }
    }
}
