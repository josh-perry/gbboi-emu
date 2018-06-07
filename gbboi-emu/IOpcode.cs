namespace gbboi_emu
{
    public interface IOpcode
    {
        string Mnemonic { get; set; }

        ushort Length { get; set; }

        short Cycles { get; set; }

        bool IncrementProgramCounter { get; set; }

        void Execute(Stack stack, Registers registers, Instruction instruction, IMemory memory);
    }
}
