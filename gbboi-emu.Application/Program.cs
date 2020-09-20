using System;
using gbboi_emu;

namespace gbboi_emu.Application
{
    class Program
    {
        static void Main(string[] args)
        {
            var cart = new Cartridge();
            cart.LoadFromFile(@"/home/jp/ROMs/Tetris.gb");

            var mmu = new Mmu();
            var cpu = new Cpu(mmu, new Registers());
            var gameboy = new GameBoy(cpu, mmu, cart);

            gameboy.PowerUp();

            gameboy.Cpu.Registers.PC.Value = 0x00;

            var cycles = 0;

            while (true)
            {
                gameboy.Cpu.Cycle();
                cycles++;

                if(cpu.Registers.PC.Value == 0x00e9)
                {
                    Console.WriteLine("End of boot");
                    Console.ReadLine();
                }

                Console.WriteLine($"Cycle: {cycles}");

                // Hack: until we emulate interrupts properly, just set the vblank manually
                gameboy.Mmu.WriteByte(0xFF44, 144);
            }
        }
    }
}
