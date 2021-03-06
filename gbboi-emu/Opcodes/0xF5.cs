using System;

namespace gbboi_emu.Opcodes
{
    /// <summary>
    /// PUSH
    ///
    /// </summary>
    [OneByteOpcode]
    public class _0xF5 : IOpcode
    {
        public string Mnemonic { get; set; } = "PUSH";

        public ushort Length { get; set; } = 1;

        public short Cycles { get; set; } = 16;

        public bool IncrementProgramCounter { get; set; } = true;

        public void Execute(Instruction instruction, ICpu cpu, IMmu mmu)
        {
            throw new NotImplementedException(Mnemonic);
        }
    }
}
