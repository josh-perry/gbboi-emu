namespace gbboi_emu
{
    public interface ICpu
    {
        IMemory Memory { get; set; }

        void FetchInstruction();

        void DecodeInstruction();

        void ExecuteInstruction();

        void Cycle();
    }
}