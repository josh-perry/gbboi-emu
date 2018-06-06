using NUnit.Framework;

namespace gbboi_emu.Tests.OpCodes
{
    [TestFixture]
    [Category("0x32")]
    public class OpCode0x32Tests
    {
        [Test]
        public void Op0x32_ASavedHLDecremented()
        {
            // Arrange
            var memory = new Memory();
            var cpu = new Cpu(memory, new Registers());
            var gameboy = new GameBoy(cpu, memory, new MockCartridge());
            gameboy.PowerUp();

            var originalHl = gameboy.Cpu.Registers.HL.Value;

            gameboy.Cpu.Registers.A.Value = 0x25;

            gameboy.Cpu.Registers.PC.Value = 0x00;
            gameboy.Memory.Bytes[0x00] = 0x32;
            gameboy.Memory.Bytes[0x01] = 0x00;

            // Act
            gameboy.Cpu.Cycle();

            // Assert
            Assert.That(gameboy.Memory.Bytes[originalHl] == gameboy.Cpu.Registers.A.Value);
            Assert.That(gameboy.Cpu.Registers.HL.Value == originalHl - 1);
        }
    }
}
