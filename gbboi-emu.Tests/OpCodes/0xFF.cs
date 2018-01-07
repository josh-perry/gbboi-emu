using NUnit.Framework;

namespace gbboi_emu.Tests.OpCodes
{
    [TestFixture]
    [Category("0xFF")]
    public class OpCode0xFFTests
    {
        [Test]
        public void Op0xFFFF_Calls0x0038()
        {
            // Arrange
            var memory = new Memory();
            var cpu = new Cpu(memory, new Registers());
            var gameboy = new GameBoy(cpu, memory, new MockCartridge());
            gameboy.PowerUp();

            var originalPC = gameboy.Cpu.Registers.PC.Value;
            var originalSP = gameboy.Cpu.Registers.SP.Value;

            gameboy.Memory.Bytes[gameboy.Cpu.Registers.PC.Value] = 0xFF;
            gameboy.Memory.Bytes[gameboy.Cpu.Registers.PC.Value + 1] = 0xFF;

            // Act
            gameboy.Cpu.Cycle();

            // Assert
            // Current item in the stack should be original PC
            Assert.That(gameboy.Memory.Bytes[gameboy.Cpu.Registers.SP.Value] == (byte)(originalPC >> 8));
            Assert.That(gameboy.Memory.Bytes[gameboy.Cpu.Registers.SP.Value + 1] == (byte)(originalPC & 0x00FF));

            // Stack pointer should have decremented
            Assert.That(gameboy.Cpu.Registers.SP.Value == originalSP - 2);

            Assert.That(gameboy.Cpu.Registers.PC.Value == 0x0038);
        }
    }
}
