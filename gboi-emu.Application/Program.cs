using gbboi_emu;

namespace gboi_emu.Application
{
    class Program
    {
        static void Main(string[] args)
        {
            var memory = new Memory();
            var cpu = new Cpu(memory, new Registers());
            var gameboy = new GameBoy(cpu, memory);

            gameboy.PowerUp();
        }
    }
}
