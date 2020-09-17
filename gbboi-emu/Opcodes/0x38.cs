using System;

namespace gbboi_emu.Opcodes
{
    /// <summary>
    /// JR
    ///
    /// </summary>
    [OneByteOpcode]
    public class _0x38 : IOpcode
    {
        public string Mnemonic { get; set; } = "JR";

        public ushort Length { get; set; } = 2;

        public short Cycles { get; set; } = 12;

        public bool IncrementProgramCounter { get; set; } = true;

        public void Execute(Stack stack, Registers registers, Instruction instruction, IMemory memory)
        {
            throw new NotImplementedException(Mnemonic);
        }
    }
}
