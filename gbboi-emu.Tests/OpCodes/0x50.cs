using NUnit.Framework;

namespace gbboi_emu.Tests.OpCodes
{
    [TestFixture]
    [Category("0x31")]
    public class OpCode0x50Tests
    {
        [Test]
        public void Op0x5001_DisB()
        {
            // Arrange
            var memory = new Memory();
            var cpu = new Cpu(memory, new Registers());
            var gameboy = new GameBoy(cpu, memory, new MockCartridge());

            gameboy.Memory.Init(0xFFFF);
            gameboy.Cpu.Registers.PC.Value = 0x00;
            gameboy.Cpu.Registers.B.Value = 0xAA;

            gameboy.Memory.Bytes[0x00] = 0x50;
            gameboy.Memory.Bytes[0x01] = 0x01;

            // Act
            gameboy.Cpu.Cycle();

            // Assert
            Assert.That(gameboy.Cpu.Registers.D.Value == 0xAA);
            Assert.That(gameboy.Cpu.Registers.D.Value == gameboy.Cpu.Registers.B.Value);
        }
    }
}