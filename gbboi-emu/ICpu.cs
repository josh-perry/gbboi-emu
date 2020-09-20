namespace gbboi_emu
{
    public interface ICpu
    {
        IMmu Mmu { get; set; }

        Instruction CurrentInstruction { get; set; }

        Registers Registers { get; set; }

        Stack Stack { get; set; }

        bool InterruptsEnabled { get; set; }

        void FetchInstruction();

        void ExecuteInstruction();

        void Cycle();

        byte ReadImmediateN();
        
        ushort ReadImmediateNN();
    }
}