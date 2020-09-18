namespace gbboi_emu
{
    public interface IOpcode
    {
        string Mnemonic { get; set; }

        ushort Length { get; set; }

        short Cycles { get; set; }

        bool IncrementProgramCounter { get; set; }

        void Execute(Instruction instruction, ICpu cpu, IMemory memory);
    }
}
