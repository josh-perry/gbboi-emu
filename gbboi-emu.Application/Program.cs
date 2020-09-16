﻿using gbboi_emu;

namespace gbboi_emu.Application
{
    class Program
    {
        static void Main(string[] args)
        {
            var cart = new Cartridge();
            cart.LoadFromFile(@"TestData/BIOS.gb");

            var memory = new Memory();
            var cpu = new Cpu(memory, new Registers());
            var gameboy = new GameBoy(cpu, memory, cart);

            gameboy.PowerUp();

            gameboy.Cpu.Registers.PC.Value = 0x00;

            while (true)
            {
                gameboy.Cpu.Cycle();
            }
        }
    }
}