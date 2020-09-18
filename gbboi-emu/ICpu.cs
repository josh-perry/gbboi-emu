namespace gbboi_emu
{
    public interface ICpu
    {
        IMemory Memory { get; set; }

        Instruction CurrentInstruction { get; set; }

        Registers Registers { get; set; }

        Stack Stack { get; set; }

        bool InterruptsEnabled { get; set; }

        void FetchInstruction();

        void ExecuteInstruction();

        void Cycle();
    }
}