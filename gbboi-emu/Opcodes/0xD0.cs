using System;

namespace gbboi_emu.Opcodes
{
    /// <summary>
    /// RET
    ///
    /// </summary>
    [OneByteOpcode]
    public class _0xD0 : IOpcode
    {
        public string Mnemonic { get; set; } = "RET";

        public ushort Length { get; set; } = 1;

        public short Cycles { get; set; } = 20;

        public bool IncrementProgramCounter { get; set; } = true;

        public void Execute(Instruction instruction, ICpu cpu, IMmu mmu)
        {
            throw new NotImplementedException(Mnemonic);
        }
    }
}
