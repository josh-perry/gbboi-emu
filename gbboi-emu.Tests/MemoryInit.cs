using System.Linq;
using NUnit.Framework;

namespace gbboi_emu.Tests
{
    [TestFixture]
    public class MemoryInit
    {
        [Test]
        public void MemoryInit_64kAllZero()
        {
            // Arrange
            var cpu = new Cpu();
            var memory = new Memory();
            var gameboy = new GameBoy(cpu, memory);

            // Act
            gameboy.Memory.Init(0xFFFF);

            // Assert
            Assert.That(gameboy.Memory.Bytes.Length == 0xFFFF);
            Assert.That(gameboy.Memory.Bytes.All(b => b == 0));
        }
    }
}