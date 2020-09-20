using NUnit.Framework;

namespace gbboi_emu.Tests
{
    [TestFixture]
    [Category("Registers")]
    public class ProgramCounter
    {
        [Test]
        public void ProgramCounterIncrementation()
        {
            // Arrange
            var mmu = new Mmu();
            var cpu = new Cpu(mmu, new Registers());
            var gameboy = new GameBoy(cpu, mmu, new MockCartridge());

            gameboy.Cpu.Registers.PC.Value = 0x0000;

            // Act + assert
            gameboy.Cpu.Cycle();
            Assert.That(gameboy.Cpu.Registers.PC.Value == 0x0001);

            gameboy.Cpu.Cycle();
            Assert.That(gameboy.Cpu.Registers.PC.Value == 0x0002);

            gameboy.Cpu.Cycle();
            Assert.That(gameboy.Cpu.Registers.PC.Value == 0x0003);
        }
    }
}