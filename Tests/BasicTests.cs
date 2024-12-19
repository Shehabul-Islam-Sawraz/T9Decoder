using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class OldPhonePadBasicTests
    {
        [TestCase("33#", "E")]
        [TestCase("227*#", "B")]
        [TestCase("4433555 555666#", "HELLO")]
        [TestCase("8 88777444666*664#", "TURING")]
        public void ProcessInput_ValidInputs_ReturnsExpectedOutput(string input, string expected)
        {
            // Act
            var result = KeyPadParser.OldPhonePad.ProcessInput(input);

            // Assert
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void ProcessInput_WithBackspace_HandlesCorrectly()
        {
            // Arrange
            var input = "4433*33555 555666#"; // HELLO with a mistake and backspace

            // Act
            var result = KeyPadParser.OldPhonePad.ProcessInput(input);

            // Assert
            Assert.That(result, Is.EqualTo("HELLO"));
        }

        [Test]
        public void ProcessInput_BackspaceCurrentInput_HandlesCorrectly()
        {
            // Arrange
            var input = "222*#"; // Try to write "C" but backspace before sending

            // Act
            var result = KeyPadParser.OldPhonePad.ProcessInput(input);

            // Assert
            Assert.That(result, Is.Empty);
        }

        [Test]
        public void ProcessInput_BackspaceWithMultipleChars_HandlesCorrectly()
        {
            // Arrange
            var input = "222 22*#"; // "CB" with backspace should return "C"

            // Act
            var result = KeyPadParser.OldPhonePad.ProcessInput(input);

            // Assert
            Assert.That(result, Is.EqualTo("C"));
        }

        [Test]
        public void ProcessInput_BackspaceAtStart_HandlesCorrectly()
        {
            // Arrange
            var input = "*2#";

            // Act
            var result = KeyPadParser.OldPhonePad.ProcessInput(input);

            // Assert
            Assert.That(result, Is.EqualTo("A"));
        }
    }
}