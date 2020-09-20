using System;

namespace gbboi_emu.Opcodes
{
    /// <summary>
    /// INC
    ///
    /// </summary>
    [OneByteOpcode]
    public class _0x34 : IOpcode
    {
        public string Mnemonic { get; set; } = "INC";

        public ushort Length { get; set; } = 1;

        public short Cycles { get; set; } = 12;

        public bool IncrementProgramCounter { get; set; } = true;

        public void Execute(Instruction instruction, ICpu cpu, IMmu mmu)
        {
            throw new NotImplementedException(Mnemonic);
        }
    }
}
