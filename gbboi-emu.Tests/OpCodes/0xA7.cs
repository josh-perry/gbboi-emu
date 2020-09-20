using NUnit.Framework;

namespace gbboi_emu.Tests.OpCodes
{
    [TestFixture]
    [Category("0xA7")]
    [Ignore("0xA7 not implemented yet!")]
    public class OpCode0xA7Tests
    {
        [Test]
        public void Op0xA7_DoesSomethingUseful()
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