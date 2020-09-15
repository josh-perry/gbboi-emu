using NUnit.Framework;

namespace gbboi_emu.Tests.OpCodes
{
    [TestFixture]
    [Category("0xCB")]
    public class OpCode0xCB7CTests
    {
        [Test]
        public void Op0xCB7C_ZeroFlagSet()
        {
            // Arrange
            var memory = new Memory();
            var cpu = new Cpu(memory, new Registers());
            var gameboy = new GameBoy(cpu, memory, new MockCartridge());
            gameboy.PowerUp();

            gameboy.Cpu.Registers.H.Value = (0x00 | (1 << 7));

            var originalPC = gameboy.Cpu.Registers.PC.Value;
            var originalSP = gameboy.Cpu.Registers.SP.Value;
            var originalCarry = gameboy.Cpu.Registers.F.CarryFlag;

            gameboy.Memory.Bytes[gameboy.Cpu.Registers.PC.Value] = 0xCB;
            gameboy.Memory.Bytes[gameboy.Cpu.Registers.PC.Value + 1] = 0x7C;

            // Act
            gameboy.Cpu.Cycle();

            // Assert
            Assert.That(gameboy.Cpu.Registers.F.HalfCarryFlag == true);
            Assert.That(gameboy.Cpu.Registers.F.SubtractFlag == false);
            Assert.That(gameboy.Cpu.Registers.F.CarryFlag == originalCarry);
            Assert.That(gameboy.Cpu.Registers.F.ZeroFlag == false);
        }

        [Test]
        public void Op0xCB7C_ZeroFlagNotSet()
        {
            // Arrange
            var memory = new Memory();
            var cpu = new Cpu(memory, new Registers());
            var gameboy = new GameBoy(cpu, memory, new MockCartridge());
            gameboy.PowerUp();

            gameboy.Cpu.Registers.H.Value = 0x00;

            var originalPC = gameboy.Cpu.Registers.PC.Value;
            var originalSP = gameboy.Cpu.Registers.SP.Value;
            var originalCarry = gameboy.Cpu.Registers.F.CarryFlag;

            gameboy.Memory.Bytes[gameboy.Cpu.Registers.PC.Value] = 0xCB;
            gameboy.Memory.Bytes[gameboy.Cpu.Registers.PC.Value + 1] = 0x7C;

            // Act
            gameboy.Cpu.Cycle();

            // Assert
            Assert.That(gameboy.Cpu.Registers.F.HalfCarryFlag == true);
            Assert.That(gameboy.Cpu.Registers.F.SubtractFlag == false);
            Assert.That(gameboy.Cpu.Registers.F.CarryFlag == originalCarry);
            Assert.That(gameboy.Cpu.Registers.F.ZeroFlag);
        }
    }
}

