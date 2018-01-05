using NUnit.Framework;

namespace gbboi_emu.Tests.OpCodes
{
    [TestFixture]
    [Category("0x0")]
    public class OpCode0x00Tests
    {
        [Test]
        public void Op0x00_DoesNothing()
        {
            // Arrange
            var memory = new Memory();
            var cpu = new Cpu(memory, new Registers());
            var gameboy = new GameBoy(cpu, memory);

            gameboy.Memory.Bytes[0x00] = 0x00;

            // Act
            gameboy.Cpu.Cycle();

            // Assert
        }
    }
}
