using System;

namespace gbboi_emu.Opcodes
{
    /// <summary>
    /// AND
    ///
    /// </summary>
    [OneByteOpcode]
    public class _0xA6 : IOpcode
    {
        public string Mnemonic { get; set; } = "AND";

        public ushort Length { get; set; } = 1;

        public short Cycles { get; set; } = 8;

        public bool IncrementProgramCounter { get; set; } = true;

        public void Execute(Stack stack, Registers registers, Instruction instruction, IMemory memory)
        {
            throw new NotImplementedException(Mnemonic);
        }
    }
}
