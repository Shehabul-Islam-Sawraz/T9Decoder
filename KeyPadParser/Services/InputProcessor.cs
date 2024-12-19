using System;
using System.Text;
using KeyPadParser.Config;
using KeyPadParser.Models;

namespace KeyPadParser.Services
{
    /// <summary>
    /// Handles the processing of keypad input sequences.
    /// </summary>
    public class InputProcessor
    {
        /// <summary>
        /// Processes a single keypad input and returns the corresponding character.
        /// </summary>
        public static char ProcessKeyPress(KeypadInput input)
        {
            if (!KeypadConfiguration.KeyMappings.TryGetValue(input.Key, out var mapping))
            {
                throw new ArgumentException($"Invalid key: {input.Key}");
            }

            var index = (input.PressCount - 1) % mapping.Length;
            return mapping[index];
        }

        /// <summary>
        /// Validates the input string for basic requirements.
        /// </summary>
        public static void ValidateInput(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                throw new ArgumentException("Input cannot be null or empty.", nameof(input));
            }

            if (!input.EndsWith("#"))
            {
                throw new ArgumentException("Input must end with the send key (#).", nameof(input));
            }
        }
    }
}