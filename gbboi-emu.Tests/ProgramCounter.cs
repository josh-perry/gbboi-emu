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
            var memory = new Memory();
            var cpu = new Cpu(memory, new Registers());
            var gameboy = new GameBoy(cpu, memory, new MockCartridge());
            gameboy.Memory.Init(0xFFFF);

            gameboy.Cpu.Registers.PC.Value = 0x0000;

            // Act + assert
            gameboy.Cpu.Cycle();
            Assert.That(gameboy.Cpu.Registers.PC.Value == 0x0002);

            gameboy.Cpu.Cycle();
            Assert.That(gameboy.Cpu.Registers.PC.Value == 0x0004);

            gameboy.Cpu.Cycle();
            Assert.That(gameboy.Cpu.Registers.PC.Value == 0x0006);
        }
    }
}