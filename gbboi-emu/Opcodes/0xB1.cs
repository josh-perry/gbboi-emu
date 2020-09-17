using System;

namespace gbboi_emu.Opcodes
{
    /// <summary>
    /// OR
    ///
    /// </summary>
    [OneByteOpcode]
    public class _0xB1 : IOpcode
    {
        public string Mnemonic { get; set; } = "OR";

        public ushort Length { get; set; } = 1;

        public short Cycles { get; set; } = 4;

        public bool IncrementProgramCounter { get; set; } = true;

        public void Execute(Stack stack, Registers registers, Instruction instruction, IMemory memory)
        {
            throw new NotImplementedException(Mnemonic);
        }
    }
}