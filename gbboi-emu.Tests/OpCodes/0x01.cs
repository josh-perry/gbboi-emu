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
            var mmu = new Mmu();
            var cpu = new Cpu(mmu, new Registers());
            var gameboy = new GameBoy(cpu, mmu, new MockCartridge());
            gameboy.PowerUp();

            const byte nn = 12;

            gameboy.Mmu.WriteByte(gameboy.Cpu.Registers.PC.Value, 0x01);
            gameboy.Mmu.WriteByte((ushort)(gameboy.Cpu.Registers.PC.Value + 1), nn);

            // Act
            gameboy.Cpu.Cycle();

            // Assert
            Assert.That(gameboy.Cpu.Registers.BC.Value == nn);
        }
    }
}
