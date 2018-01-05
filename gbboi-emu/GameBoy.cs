namespace gbboi_emu
{
    public class GameBoy
    {
        public Registers Registers; 
     
        public ICpu Cpu;

        public IMemory Memory;

        public GameBoy(ICpu cpu, IMemory memory)
        {
            Cpu = cpu;
            Memory = memory;
        }
    }
}
