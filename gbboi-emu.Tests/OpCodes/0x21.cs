using NUnit.Framework;

namespace gbboi_emu.Tests.OpCodes
{
    [TestFixture]
    [Category("0x21")]
    public class OpCode0x21Tests
    {
        [Test]
        public void Op0x21_NNIsLoadedIntoRegisterHL()
        {
            // Arrange
            var memory = new Memory();
            var cpu = new Cpu(memory, new Registers());
            var gameboy = new GameBoy(cpu, memory, new MockCartridge());
            gameboy.PowerUp();

            gameboy.Memory.Bytes[gameboy.Cpu.Registers.PC.Value] = 0x21;
            gameboy.Memory.Bytes[gameboy.Cpu.Registers.PC.Value + 1] = 0x34;
            gameboy.Memory.Bytes[gameboy.Cpu.Registers.PC.Value + 2] = 0x12;

            // Act
            gameboy.Cpu.Cycle();

            // Assert
            Assert.That(gameboy.Cpu.Registers.HL.Value == 0x1234);
        }
    }
}
