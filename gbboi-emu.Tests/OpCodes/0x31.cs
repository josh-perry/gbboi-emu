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
            var mmu = new Mmu();
            var cpu = new Cpu(mmu, new Registers());
            var gameboy = new GameBoy(cpu, mmu, new MockCartridge());

            gameboy.Cpu.Registers.PC.Value = 0x00;
            gameboy.Mmu.WriteByte(0x00, 0x31);
            gameboy.Mmu.WriteByte(0x01, 0xFE);

            // Act
            gameboy.Cpu.Cycle();

            // Assert
            Assert.That(gameboy.Cpu.Registers.SP.Value == 0xFE);
        }

        [Test]
        public void Op0x3111_SpIs0x11()
        {
            // Arrange
            var mmu = new Mmu();
            var cpu = new Cpu(mmu, new Registers());
            var gameboy = new GameBoy(cpu, mmu, new MockCartridge());

            gameboy.Cpu.Registers.PC.Value = 0x00;
            gameboy.Mmu.WriteByte(0x00, 0x31);
            gameboy.Mmu.WriteByte(0x01, 0x11);

            // Act
            gameboy.Cpu.Cycle();

            // Assert
            Assert.That(gameboy.Cpu.Registers.SP.Value == 0x11);
        }
    }
}
