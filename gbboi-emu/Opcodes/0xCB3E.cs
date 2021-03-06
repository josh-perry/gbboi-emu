using System;

namespace gbboi_emu.Opcodes
{
    /// <summary>
    /// SRL
    ///
    /// </summary>
    [TwoByteOpcode]
    public class _0xCB3E : IOpcode
    {
        public string Mnemonic { get; set; } = "SRL";

        public ushort Length { get; set; } = 2;

        public short Cycles { get; set; } = 16;

        public bool IncrementProgramCounter { get; set; } = true;

        public void Execute(Instruction instruction, ICpu cpu, IMmu mmu)
        {
            throw new NotImplementedException(Mnemonic);
        }
    }
}
