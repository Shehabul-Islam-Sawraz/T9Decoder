using System;

namespace KeyPadParser.Models
{
    /// <summary>
    /// Represents a single keypad input with its associated press count.
    /// </summary>
    public class KeypadInput
    {
        public char Key { get; }
        public int PressCount { get; private set; }

        public KeypadInput(char key)
        {
            Key = key;
            PressCount = 1;
        }

        public void IncrementPressCount()
        {
            PressCount++;
        }

        public void Reset()
        {
            PressCount = 1;
        }
    }
}