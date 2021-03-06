﻿using NUnit.Framework;

namespace gbboi_emu.Tests.OpCodes
{
    [TestFixture]
    [Category("0x66")]
    public class OpCode0x66Tests
    {
        [Test]
        public void Op0x66_PointTo0xBBHIs0xBB()
        {
            // Arrange
            var mmu = new Mmu();
            var cpu = new Cpu(mmu, new Registers());
            var gameboy = new GameBoy(cpu, mmu, new MockCartridge());
            gameboy.PowerUp();

            gameboy.Cpu.Registers.PC.Value = 0x00;
            gameboy.Cpu.Registers.HL.Value = 0xFF00;
            
            gameboy.Mmu.WriteByte(0x00, 0x66);
            gameboy.Mmu.WriteByte(0x01, 0x00);
            gameboy.Mmu.WriteByte(0xFF00, 0xBB);

            // Act
            gameboy.Cpu.Cycle();

            // Assert
            Assert.That(gameboy.Cpu.Registers.H.Value == 0xBB);
        }
    }
}
