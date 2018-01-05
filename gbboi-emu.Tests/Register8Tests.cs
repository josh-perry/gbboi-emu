using NUnit.Framework;

namespace gbboi_emu.Tests
{
    [TestFixture]
    [Category("Registers")]
    public class Register8Tests
    {
        [Test]
        public void EmptyRegister8()
        {
            // Arrange
            var register8 = new Register8();

            // Act

            // Assert
            Assert.That(register8.Value == 0x00);
        }

        [Test]
        public void SettingRegister8Value()
        {
            // Arrange
            var register8 = new Register8();

            // Act
            register8.Value = 0x01;

            // Assert
            Assert.That(register8.Value == 0x01);
        }
    }
}
