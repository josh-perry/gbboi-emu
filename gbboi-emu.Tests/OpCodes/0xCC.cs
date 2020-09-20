using System;
using NUnit.Framework;

namespace gbboi_emu.Tests.OpCodes
{
    [TestFixture]
    [Category("0xCC")]
    public class OpCode0xCCTests
    {
        [Test]
        public void Op0xCC_ZeroFlagIsSet_SPIsSetOldSPOnStack()
        {
            // Arrange
            var mmu = new Mmu();
            var cpu = new Cpu(mmu, new Registers());
            var gameboy = new GameBoy(cpu, mmu, new MockCartridge());
            gameboy.PowerUp();

            gameboy.Cpu.Registers.F.ZeroFlag = true;
            var originalPC = gameboy.Cpu.Registers.PC.Value;
            var originalSP = gameboy.Cpu.Registers.SP.Value;

            gameboy.Mmu.WriteByte(gameboy.Cpu.Registers.PC.Value, 0xCC);
            gameboy.Mmu.WriteByte((ushort)(gameboy.Cpu.Registers.PC.Value + 1), 0x55);

            // Act
            gameboy.Cpu.Cycle();

            // Assert
            // Zero flag should be set
            Assert.That(gameboy.Cpu.Registers.F.ZeroFlag);

            // Current item in the stack should be original PC
            Assert.That(gameboy.Mmu.ReadByte(gameboy.Cpu.Registers.SP.Value) == (byte)(originalPC >> 8));
            Assert.That(gameboy.Mmu.ReadByte((ushort)(gameboy.Cpu.Registers.SP.Value + 1)) == (byte)(originalPC & 0x00FF));

            // Stack pointer should have decremented
            Assert.That(gameboy.Cpu.Registers.SP.Value == originalSP);

            // PC should be NN
            Assert.That(gameboy.Cpu.Registers.PC.Value == 0x55);
        }

        [Test]
        public void Op0xCC_ZeroFlagIsNotSet_NoOp()
        {
            // Arrange
            var mmu = new Mmu();
            var cpu = new Cpu(mmu, new Registers());
            var gameboy = new GameBoy(cpu, mmu, new MockCartridge());
            gameboy.PowerUp();

            gameboy.Cpu.Registers.F.ZeroFlag = false;
            var originalPC = gameboy.Cpu.Registers.PC.Value;
            var originalSP = gameboy.Cpu.Registers.SP.Value;

            gameboy.Mmu.BiosMapped = false;
            gameboy.Mmu.WriteByte(gameboy.Cpu.Registers.PC.Value, 0xCC);
            gameboy.Mmu.WriteByte((ushort)(gameboy.Cpu.Registers.PC.Value + 1), 0x55);

            // Act
            gameboy.Cpu.Cycle();

            // Assert
            // Zero flag should be set
            Assert.That(!gameboy.Cpu.Registers.F.ZeroFlag);

            // Stack pointer should not have shifted
            Assert.That(gameboy.Cpu.Registers.SP.Value == originalSP);

            // Program counter should have shifted by 2 but NOT be at 0x55
            Assert.That(gameboy.Cpu.Registers.PC.Value != 0x55);
            Assert.That(gameboy.Cpu.Registers.PC.Value == originalPC + 3);
        }
    }
}
