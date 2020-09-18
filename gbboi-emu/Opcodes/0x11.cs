using System;

namespace gbboi_emu.Opcodes
{
    /// <summary>
    /// LD
    ///
    /// </summary>
    [OneByteOpcode]
    public class _0x11 : IOpcode
    {
        public string Mnemonic { get; set; } = "LD";

        public ushort Length { get; set; } = 3;

        public short Cycles { get; set; } = 12;

        public bool IncrementProgramCounter { get; set; } = true;

        public void Execute(Instruction instruction, ICpu cpu, IMemory memory)
        {
            throw new NotImplementedException(Mnemonic);
        }
    }
}
