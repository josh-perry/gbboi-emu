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
            var mmu = new Mmu();
            var cpu = new Cpu(mmu, new Registers());
            var gameboy = new GameBoy(cpu, mmu, new MockCartridge());
            gameboy.PowerUp();

            gameboy.Mmu.WriteByte(gameboy.Cpu.Registers.PC.Value, 0xC3);
            gameboy.Mmu.WriteByte((ushort)(gameboy.Cpu.Registers.PC.Value + 1), 0x34);
            gameboy.Mmu.WriteByte((ushort)(gameboy.Cpu.Registers.PC.Value + 2), 0x12);

            // Act
            gameboy.Cpu.Cycle();

            // Assert
            Assert.That(gameboy.Cpu.Registers.PC.Value == 0x1234);
        }
    }
}
