using System;

namespace gbboi_emu.Opcodes
{
    /// <summary>
    /// LDH
    ///
    /// </summary>
    [OneByteOpcode]
    public class _0xF0 : IOpcode
    {
        public string Mnemonic { get; set; } = "LDH";

        public ushort Length { get; set; } = 2;

        public short Cycles { get; set; } = 12;

        public bool IncrementProgramCounter { get; set; } = true;

        public void Execute(Instruction instruction, ICpu cpu, IMemory memory)
        {
            throw new NotImplementedException(Mnemonic);
        }
    }
}
