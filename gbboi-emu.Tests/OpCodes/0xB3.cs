using NUnit.Framework;

namespace gbboi_emu.Tests.OpCodes
{
    [TestFixture]
    [Category("0xB3")]
    [Ignore("0xB3 not implemented yet!")]
    public class OpCode0xB3Tests
    {
        [Test]
        public void Op0xB3_DoesSomethingUseful()
        {
            // Arrange
            var mmu = new Mmu();
            var cpu = new Cpu(mmu, new Registers());
            var gameboy = new GameBoy(cpu, mmu, new MockCartridge());
            gameboy.PowerUp();

            gameboy.Cpu.Registers.PC.Value = 0;
            // gameboy.Mmu.WriteByte(0x00, 0x00;
            // gameboy.Mmu.WriteByte(0x01, 0x00;

            // Act
            gameboy.Cpu.Cycle();

            // Assert
            // Assert.That(true);
        }
    }
}