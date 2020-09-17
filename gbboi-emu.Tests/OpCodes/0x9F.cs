using NUnit.Framework;

namespace gbboi_emu.Tests.OpCodes
{
    [TestFixture]
    [Category("0x9F")]
    [Ignore("0x9F not implemented yet!")]
    public class OpCode0x9FTests
    {
        [Test]
        public void Op0x9F_DoesSomethingUseful()
        {
            // Arrange
            var memory = new Memory();
            var cpu = new Cpu(memory, new Registers());
            var gameboy = new GameBoy(cpu, memory, new MockCartridge());
            gameboy.PowerUp();

            gameboy.Cpu.Registers.PC.Value = 0;
            // gameboy.Memory.Bytes[0x00] = 0x00;
            // gameboy.Memory.Bytes[0x01] = 0x00;

            // Act
            gameboy.Cpu.Cycle();

            // Assert
            // Assert.That(true);
        }
    }
}