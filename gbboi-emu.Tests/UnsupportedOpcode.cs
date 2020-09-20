using gbboi_emu.Exceptions;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;

namespace gbboi_emu.Tests.OpCodes
{
    [TestFixture]
    [Category("Unsupported Opcodes")]
    public class UnsupportedOpcodesTests
    {
        [TestCase(0xD3)]
        [TestCase(0xDB)]
        [TestCase(0xDD)]
        [TestCase(0xE3)]
        [TestCase(0xE4)]
        [TestCase(0xEB)]
        [TestCase(0xEC)]
        [TestCase(0xED)]
        [TestCase(0xF2)]
        [TestCase(0xF4)]
        [TestCase(0xFC)]
        [TestCase(0xFD)]
        public void UnsupportedOpcode_ThrowsUnsupportedException(byte op)
        {
            // Arrange
            var mmu = new Mmu();
            var cpu = new Cpu(mmu, new Registers());
            var gameboy = new GameBoy(cpu, mmu, new MockCartridge());
            gameboy.PowerUp();

            gameboy.Cpu.Registers.PC.Value = 0x00;
            gameboy.Mmu.WriteByte(0x00, op);
            gameboy.Mmu.WriteByte(0x01, 0x00);

            // Act
            // Assert
            Assert.Throws<OperationNotSupportedByCpuException>(() => gameboy.Cpu.Cycle());
        }
    }
}
