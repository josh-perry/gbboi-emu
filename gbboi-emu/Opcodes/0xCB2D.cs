using System;

namespace gbboi_emu.Opcodes
{
    /// <summary>
    /// SRA
    ///
    /// </summary>
    [TwoByteOpcode]
    public class _0xCB2D : IOpcode
    {
        public string Mnemonic { get; set; } = "SRA";

        public ushort Length { get; set; } = 2;

        public short Cycles { get; set; } = 8;

        public bool IncrementProgramCounter { get; set; } = true;

        public void Execute(Instruction instruction, ICpu cpu, IMmu mmu)
        {
            throw new NotImplementedException(Mnemonic);
        }
    }
}
