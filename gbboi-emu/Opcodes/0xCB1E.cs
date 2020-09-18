using System;

namespace gbboi_emu.Opcodes
{
    /// <summary>
    /// RR
    ///
    /// </summary>
    [TwoByteOpcode]
    public class _0xCB1E : IOpcode
    {
        public string Mnemonic { get; set; } = "RR";

        public ushort Length { get; set; } = 2;

        public short Cycles { get; set; } = 16;

        public bool IncrementProgramCounter { get; set; } = true;

        public void Execute(Instruction instruction, ICpu cpu, IMemory memory)
        {
            throw new NotImplementedException(Mnemonic);
        }
    }
}
