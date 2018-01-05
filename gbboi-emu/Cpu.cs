namespace gbboi_emu
{
    public class Cpu : ICpu
    {
        public IMemory Memory { get; set; }

        public Cpu(IMemory memory)
        {
            Memory = memory;
        }

        public void FetchInstruction()
        {
        }

        public void DecodeInstruction()
        {
        }

        public void ExecuteInstruction()
        {
        }

        public void Cycle()
        {
        }
    }
}