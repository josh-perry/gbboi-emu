using System.Collections;
using NUnit.Framework;

namespace gbboi_emu.Tests.OpCodes
{
    [TestFixture]
    [Category("0xCE")]
    public class OpCode0xCETests
    {
        [Test]
        public void Op0xCE_1Plus2NoCarry()
        {
            // Arrange
            var memory = new Memory();
            var cpu = new Cpu(memory, new Registers());
            var gameboy = new GameBoy(cpu, memory, new MockCartridge());
            gameboy.PowerUp();

            gameboy.Cpu.Registers.A.Value = 0x01;

            gameboy.Cpu.Registers.PC.Value = 0x00;
            gameboy.Memory.Bytes[0x00] = 0xCE;
            gameboy.Memory.Bytes[0x01] = 0x02;

            // Act
            gameboy.Cpu.Cycle();

            // Assert
            Assert.That(gameboy.Cpu.Registers.A.Value == 0x03);
            Assert.That(gameboy.Cpu.Registers.F.CarryFlag == false);
        }

        [Test]
        public void Op0xCE_250Plus10Carry()
        {
            // Arrange
            var memory = new Memory();
            var cpu = new Cpu(memory, new Registers());
            var gameboy = new GameBoy(cpu, memory, new MockCartridge());
            gameboy.PowerUp();

            gameboy.Cpu.Registers.A.Value = 0xFA;

            gameboy.Cpu.Registers.PC.Value = 0x00;
            gameboy.Memory.Bytes[0x00] = 0xCE;
            gameboy.Memory.Bytes[0x01] = 0x0A;

            // Act
            gameboy.Cpu.Cycle();

            // Assert
            Assert.That(gameboy.Cpu.Registers.A.Value == 0x04);
            Assert.That(gameboy.Cpu.Registers.F.CarryFlag == true);
        }
    }
}
