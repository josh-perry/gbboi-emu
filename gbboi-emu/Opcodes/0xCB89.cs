using System;

namespace gbboi_emu.Opcodes
{
    /// <summary>
    /// RES
    ///
    /// </summary>
    [TwoByteOpcode]
    public class _0xCB89 : IOpcode
    {
        public string Mnemonic { get; set; } = "RES";

        public ushort Length { get; set; } = 2;

        public short Cycles { get; set; } = 8;

        public bool IncrementProgramCounter { get; set; } = true;

        public void Execute(Instruction instruction, ICpu cpu, IMemory memory)
        {
            throw new NotImplementedException(Mnemonic);
        }
    }
}
