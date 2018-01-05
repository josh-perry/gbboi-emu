using System.Linq;
using NUnit.Framework;

namespace gbboi_emu.Tests
{
    [TestFixture]
    [Category("Memory")]
    public class MemoryInit
    {
        [Test]
        public void MemoryInit_64kAllZero()
        {
            // Arrange
            var memory = new Memory();
            var cpu = new Cpu(memory, new Registers());
            var gameboy = new GameBoy(cpu, memory);

            // Act
            gameboy.Memory.Init(0xFFFF);

            // Assert
            Assert.That(gameboy.Memory.Bytes.Length == 0xFFFF);
            Assert.That(gameboy.Memory.Bytes.All(b => b == 0));
        }

        [Test]
        public void LoadDmgBootloader()
        {
            // Arrange
            var memory = new Memory();
            var cpu = new Cpu(memory, new Registers());
            var gameboy = new GameBoy(cpu, memory);

            // Act
            gameboy.Memory.Init(0xFFFF);
            gameboy.Memory.LoadMemoryBankFromFile(@"G:\DMG_ROM.bin", 0);
            
            // Assert
            Assert.That(gameboy.Memory.Bytes[0x00] == 0x31);
            Assert.That(gameboy.Memory.Bytes[0x01] == 0xFE);
            Assert.That(gameboy.Memory.Bytes[0xFE] == 0xE0);
            Assert.That(gameboy.Memory.Bytes[0xFF] == 0x50);
        }
    }
}