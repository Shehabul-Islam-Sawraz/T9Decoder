using System;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    [Category("ErrorTests")]
    public class OldPhonePadErrorTests
    {
        [TestCase("")]
        [TestCase(null)]
        public void ProcessInput_NullOrEmptyInput_ThrowsArgumentException(string? input)
        {
            // Act & Assert
            var ex = Assert.Throws<ArgumentException>(() => KeyPadParser.OldPhonePad.ProcessInput(input));
            Assert.That(ex!.Message, Does.Contain("Input cannot be null or empty"));
        }

        [Test]
        public void ProcessInput_InputWithoutSendKey_ThrowsArgumentException()
        {
            // Arrange
            var input = "333";

            // Act & Assert
            var ex = Assert.Throws<ArgumentException>(() => KeyPadParser.OldPhonePad.ProcessInput(input));
            Assert.That(ex!.Message, Does.Contain("must end with the send key"));
        }

        [Test]
        public void ProcessInput_InvalidKey_ThrowsArgumentException()
        {
            // Arrange
            var input = "A#";

            // Act & Assert
            var ex = Assert.Throws<ArgumentException>(() => KeyPadParser.OldPhonePad.ProcessInput(input));
            Assert.That(ex!.Message, Does.Contain("Invalid key"));
        }
    }
}