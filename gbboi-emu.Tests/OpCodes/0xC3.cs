using NUnit.Framework;

namespace gbboi_emu.Tests.OpCodes
{
    [TestFixture]
    [Category("0xC3")]
    public class OpCode0xC3Tests
    {
        [Test]
        public void Op0xC3_JumpsToNN()
        {
            // Arrange
            var memory = new Memory();
            var cpu = new Cpu(memory, new Registers());
            var gameboy = new GameBoy(cpu, memory, new MockCartridge());
            gameboy.PowerUp();

            byte nn = 33;

            gameboy.Memory.Bytes[gameboy.Cpu.Registers.PC.Value] = 0xC3;
            gameboy.Memory.Bytes[gameboy.Cpu.Registers.PC.Value + 1] = nn;

            // Act
            gameboy.Cpu.Cycle();

            // Assert
            Assert.That(gameboy.Cpu.Registers.PC.Value == nn);
        }
    }
}
