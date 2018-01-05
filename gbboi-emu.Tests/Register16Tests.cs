using NUnit.Framework;

namespace gbboi_emu.Tests
{
    [TestFixture]
    [Category("Registers")]
    public class Register16Tests
    {
        [Test]
        public void EmptyRegister16()
        {
            // Arrange
            var register16 = new Register16(new Register8(), new Register8());

            // Act

            // Assert
            Assert.That(register16.Value == 0x0000);
        }
        
        [Test]
        public void SettingRegister16Value()
        {
            // Arrange
            var firstRegister8 = new Register8();
            var secondRegister8 = new Register8();
            var register16 = new Register16(firstRegister8, secondRegister8);

            // Act
            register16.Value = 0x1122;

            // Assert
            Assert.That(register16.Value == 0x1122);

            Assert.That(firstRegister8.Value == 0x11);
            Assert.That(secondRegister8.Value == 0x22);
        }

        [Test]
        public void SettingRegister8ValuePartOfRegister16()
        {
            // Arrange
            var firstRegister8 = new Register8();
            var secondRegister8 = new Register8();
            var register16 = new Register16(firstRegister8, secondRegister8);

            // Act
            firstRegister8.Value = 0xAA;

            // Assert
            Assert.That(register16.Value == 0xAA00);

            Assert.That(firstRegister8.Value == 0xAA);
            Assert.That(secondRegister8.Value == 0x00);
        }

        [Test]
        public void Setting2Register8ValuesPartOfRegister16()
        {
            // Arrange
            var firstRegister8 = new Register8();
            var secondRegister8 = new Register8();
            var register16 = new Register16(firstRegister8, secondRegister8);

            // Act
            firstRegister8.Value = 0xAA;
            secondRegister8.Value = 0xBB;

            // Assert
            Assert.That(register16.Value == 0xAABB);

            Assert.That(firstRegister8.Value == 0xAA);
            Assert.That(secondRegister8.Value == 0xBB);
        }
    }
}
