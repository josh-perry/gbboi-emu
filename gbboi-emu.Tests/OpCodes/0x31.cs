using NUnit.Framework;

namespace gbboi_emu.Tests.OpCodes
{
    [TestFixture]
    [Category("0x31")]
    public class OpCode0x31Tests
    {
        [Test]
        public void Op0x31FE_SpIs0xFE()
        {
            // Arrange
            var memory = new Memory();
            var cpu = new Cpu(memory, new Registers());
            var gameboy = new GameBoy(cpu, memory);

            gameboy.Memory.Init(0xFFFF);
            gameboy.Memory.Bytes[0x00] = 0x31;
            gameboy.Memory.Bytes[0x01] = 0xFE;

            // Act
            gameboy.Cpu.Cycle();

            // Assert
            Assert.That(gameboy.Cpu.Registers.SP.Value == 0xFE);
        }

        [Test]
        public void Op0x3111_SpIs0x11()
        {
            // Arrange
            var memory = new Memory();
            var cpu = new Cpu(memory, new Registers());
            var gameboy = new GameBoy(cpu, memory);

            gameboy.Memory.Init(0xFFFF);
            gameboy.Memory.Bytes[0x00] = 0x31;
            gameboy.Memory.Bytes[0x01] = 0x11;

            // Act
            gameboy.Cpu.Cycle();

            // Assert
            Assert.That(gameboy.Cpu.Registers.SP.Value == 0x11);
        }
    }
}
