using NUnit.Framework;

namespace gbboi_emu.Tests.OpCodes
{
    [TestFixture]
    [Category("0x01")]
    public class OpCode0x01Tests
    {
        [Test]
        public void Op0x01_NNIsLoadedIntoRegisterBC()
        {
            // Arrange
            var memory = new Memory();
            var cpu = new Cpu(memory, new Registers());
            var gameboy = new GameBoy(cpu, memory, new MockCartridge());
            gameboy.PowerUp();

            const byte nn = 12;

            gameboy.Memory.Bytes[gameboy.Cpu.Registers.PC.Value] = 0x01;
            gameboy.Memory.Bytes[gameboy.Cpu.Registers.PC.Value + 1] = nn;

            // Act
            gameboy.Cpu.Cycle();

            // Assert
            Assert.That(gameboy.Cpu.Registers.BC.Value == nn);
        }
    }
}
