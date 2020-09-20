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
            var mmu = new Mmu();
            var cpu = new Cpu(mmu, new Registers());
            var gameboy = new GameBoy(cpu, mmu, new MockCartridge());
            gameboy.PowerUp();

            gameboy.Cpu.Registers.PC.Value = 0x00;
            gameboy.Mmu.WriteByte(0x00, 0x00);
            gameboy.Mmu.WriteByte(0x01, 0x00);

            // Act
            gameboy.Cpu.Cycle();

            // Assert
        }
    }
}
