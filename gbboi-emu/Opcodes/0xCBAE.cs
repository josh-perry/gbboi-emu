using System;

namespace gbboi_emu.Opcodes
{
    /// <summary>
    /// RES
    ///
    /// </summary>
    [TwoByteOpcode]
    public class _0xCBAE : IOpcode
    {
        public string Mnemonic { get; set; } = "RES";

        public ushort Length { get; set; } = 2;

        public short Cycles { get; set; } = 16;

        public bool IncrementProgramCounter { get; set; } = true;

        public void Execute(Stack stack, Registers registers, Instruction instruction, IMemory memory)
        {
            throw new NotImplementedException(Mnemonic);
        }
    }
}
