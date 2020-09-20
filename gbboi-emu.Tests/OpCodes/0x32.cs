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
            var mmu = new Mmu();
            var cpu = new Cpu(mmu, new Registers());
            var gameboy = new GameBoy(cpu, mmu, new MockCartridge());
            gameboy.PowerUp();

            var originalHl = gameboy.Cpu.Registers.HL.Value;

            gameboy.Cpu.Registers.A.Value = 0x25;

            gameboy.Cpu.Registers.PC.Value = 0x00;
            gameboy.Mmu.WriteByte(0x00, 0x32);
            gameboy.Mmu.WriteByte(0x01, 0x00);

            // Act
            gameboy.Cpu.Cycle();

            // Assert
            Assert.That(gameboy.Mmu.ReadByte(originalHl) == gameboy.Cpu.Registers.A.Value);
            Assert.That(gameboy.Cpu.Registers.HL.Value == originalHl - 1);
        }
    }
}
