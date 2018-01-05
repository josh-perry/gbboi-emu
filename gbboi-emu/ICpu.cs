namespace gbboi_emu
{
    public interface ICpu
    {
        void FetchInstruction();

        void DecodeInstruction();

        void ExecuteInstruction();

        void Cycle();
    }
}