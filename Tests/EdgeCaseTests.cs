using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class OldPhonePadEdgeCaseTests
    {
        [Test]
        public void ProcessInput_OnlySpacesAndSendKey_ReturnsEmptyString()
        {
            // Arrange
            var input = "   #";

            // Act
            var result = KeyPadParser.OldPhonePad.ProcessInput(input);

            // Assert
            Assert.That(result, Is.Empty);
        }

        [Test]
        public void ProcessInput_MaximumPressesOnSingleKey_WrapsCorrectly()
        {
            // Arrange
            var input = "22222#"; // Pressing '2' five times should wrap back to 'B'

            // Act
            var result = KeyPadParser.OldPhonePad.ProcessInput(input);

            // Assert
            Assert.That(result, Is.EqualTo("B"));
        }

        [Test]
        public void ProcessInput_MultipleConsecutiveSpaces_HandlesCorrectly()
        {
            // Arrange
            var input = "2   2#";

            // Act
            var result = KeyPadParser.OldPhonePad.ProcessInput(input);

            // Assert
            Assert.That(result, Is.EqualTo("AA"));
        }

        [Test]
        public void ProcessInput_AllPossibleCharacters_HandlesCorrectly()
        {
            // Arrange
            var input = "1 11 111 2 22 222 3 33 333 4 44 444 5 55 555 6 66 666 7 77 777 7777 8 88 888 0 9 99 999 9999#";

            // Act
            var result = KeyPadParser.OldPhonePad.ProcessInput(input);

            // Assert
            Assert.That(result, Is.EqualTo("&'(ABCDEFGHIJKLMNOPQRSTUV WXYZ"));
        }
    }
}