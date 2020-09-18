using System;

namespace gbboi_emu.Opcodes
{
    /// <summary>
    /// LD
    ///
    /// </summary>
    [OneByteOpcode]
    public class _0x16 : IOpcode
    {
        public string Mnemonic { get; set; } = "LD";

        public ushort Length { get; set; } = 2;

        public short Cycles { get; set; } = 8;

        public bool IncrementProgramCounter { get; set; } = true;

        public void Execute(Instruction instruction, ICpu cpu, IMemory memory)
        {
            throw new NotImplementedException(Mnemonic);
        }
    }
}
