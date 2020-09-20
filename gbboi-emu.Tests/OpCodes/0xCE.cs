using System.Collections;
using NUnit.Framework;

namespace gbboi_emu.Tests.OpCodes
{
    [TestFixture]
    [Category("0xCE")]
    public class OpCode0xCETests
    {
        [Test]
        public void Op0xCE_1Plus2NoCarry()
        {
            // Arrange
            var mmu = new Mmu();
            var cpu = new Cpu(mmu, new Registers());
            var gameboy = new GameBoy(cpu, mmu, new MockCartridge());
            gameboy.PowerUp();

            gameboy.Cpu.Registers.A.Value = 0x01;

            gameboy.Cpu.Registers.PC.Value = 0x00;
            gameboy.Mmu.WriteByte(0x00, 0xCE);
            gameboy.Mmu.WriteByte(0x01, 0x02);

            // Act
            gameboy.Cpu.Cycle();

            // Assert
            Assert.That(gameboy.Cpu.Registers.A.Value == 0x03);
            Assert.That(gameboy.Cpu.Registers.F.CarryFlag == false);
            Assert.That(gameboy.Cpu.Registers.F.SubtractFlag == false);
            Assert.That(gameboy.Cpu.Registers.F.ZeroFlag == false);
        }

        [Test]
        public void Op0xCE_250Plus10Carry()
        {
            // Arrange
            var mmu = new Mmu();
            var cpu = new Cpu(mmu, new Registers());
            var gameboy = new GameBoy(cpu, mmu, new MockCartridge());
            gameboy.PowerUp();

            gameboy.Cpu.Registers.A.Value = 0xFA;

            gameboy.Cpu.Registers.PC.Value = 0x00;
            gameboy.Mmu.WriteByte(0x00, 0xCE);
            gameboy.Mmu.WriteByte(0x01, 0x0A);

            // Act
            gameboy.Cpu.Cycle();

            // Assert
            Assert.That(gameboy.Cpu.Registers.A.Value == 0x04);
            Assert.That(gameboy.Cpu.Registers.F.CarryFlag == true);
            Assert.That(gameboy.Cpu.Registers.F.SubtractFlag == false);
            Assert.That(gameboy.Cpu.Registers.F.ZeroFlag == false);
        }

        [Test]
        public void Op0xCE_250Plus6CarryZero()
        {
            // Arrange
            var mmu = new Mmu();
            var cpu = new Cpu(mmu, new Registers());
            var gameboy = new GameBoy(cpu, mmu, new MockCartridge());
            gameboy.PowerUp();

            gameboy.Cpu.Registers.A.Value = 0xFA;

            gameboy.Cpu.Registers.PC.Value = 0x00;
            gameboy.Mmu.WriteByte(0x00, 0xCE);
            gameboy.Mmu.WriteByte(0x01, 0x06);

            // Act
            gameboy.Cpu.Cycle();

            // Assert
            Assert.That(gameboy.Cpu.Registers.A.Value == 0x00);
            Assert.That(gameboy.Cpu.Registers.F.CarryFlag == true);
            Assert.That(gameboy.Cpu.Registers.F.SubtractFlag == false);
            Assert.That(gameboy.Cpu.Registers.F.ZeroFlag == true);
        }

        [Test]
        public void Op0xCE_10Plus12HalfCarry()
        {
            // Arrange
            var mmu = new Mmu();
            var cpu = new Cpu(mmu, new Registers());
            var gameboy = new GameBoy(cpu, mmu, new MockCartridge());
            gameboy.PowerUp();

            gameboy.Cpu.Registers.A.Value = 0x0A;

            gameboy.Cpu.Registers.PC.Value = 0x00;
            gameboy.Mmu.WriteByte(0x00, 0xCE);
            gameboy.Mmu.WriteByte(0x01, 0x0C);

            // Act
            gameboy.Cpu.Cycle();

            // Assert
            Assert.That(gameboy.Cpu.Registers.A.Value == 0x16);
            Assert.That(gameboy.Cpu.Registers.F.CarryFlag == false);
            Assert.That(gameboy.Cpu.Registers.F.SubtractFlag == false);
            Assert.That(gameboy.Cpu.Registers.F.ZeroFlag == false);
            Assert.That(gameboy.Cpu.Registers.F.HalfCarryFlag == true);
        }

        [Test]
        public void Op0xCE_5Plus4HalfCarry()
        {
            // Arrange
            var mmu = new Mmu();
            var cpu = new Cpu(mmu, new Registers());
            var gameboy = new GameBoy(cpu, mmu, new MockCartridge());
            gameboy.PowerUp();

            gameboy.Cpu.Registers.A.Value = 0x05;

            gameboy.Cpu.Registers.PC.Value = 0x00;
            gameboy.Mmu.WriteByte(0x00, 0xCE);
            gameboy.Mmu.WriteByte(0x01, 0x04);

            // Act
            gameboy.Cpu.Cycle();

            // Assert
            Assert.That(gameboy.Cpu.Registers.A.Value == 0x09);
            Assert.That(gameboy.Cpu.Registers.F.CarryFlag == false);
            Assert.That(gameboy.Cpu.Registers.F.SubtractFlag == false);
            Assert.That(gameboy.Cpu.Registers.F.ZeroFlag == false);
            Assert.That(gameboy.Cpu.Registers.F.HalfCarryFlag == false);
        }
    }
}
