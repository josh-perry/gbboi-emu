using NUnit.Framework;

namespace gbboi_emu.Tests.OpCodes
{
    [TestFixture]
    [Category("0x50")]
    public class OpCode0x50Tests
    {
        [Test]
        public void Op0x5001_DisB()
        {
            // Arrange
            var mmu = new Mmu();
            var cpu = new Cpu(mmu, new Registers());
            var gameboy = new GameBoy(cpu, mmu, new MockCartridge());

            //gameboy.Memory.Init(0xFFFF);
            gameboy.Cpu.Registers.PC.Value = 0x00;
            gameboy.Cpu.Registers.B.Value = 0xAA;

            gameboy.Mmu.WriteByte(0x00, 0x50);
            gameboy.Mmu.WriteByte(0x01, 0x01);

            // Act
            gameboy.Cpu.Cycle();

            // Assert
            Assert.That(gameboy.Cpu.Registers.D.Value == 0xAA);
            Assert.That(gameboy.Cpu.Registers.D.Value == gameboy.Cpu.Registers.B.Value);
        }
    }
}