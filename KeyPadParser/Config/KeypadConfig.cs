using System.Collections.Generic;

namespace KeyPadParser.Config
{
    /// <summary>
    /// Provides configuration for the old phone keypad mappings.
    /// </summary>
    public static class KeypadConfiguration
    {
        /// <summary>
        /// Maps keypad numbers to their corresponding characters.
        /// </summary>
        public static readonly IReadOnlyDictionary<char, string> KeyMappings = new Dictionary<char, string>
        {
            {'1', "&'("},
            {'2', "ABC"},
            {'3', "DEF"},
            {'4', "GHI"},
            {'5', "JKL"},
            {'6', "MNO"},
            {'7', "PQRS"},
            {'8', "TUV"},
            {'9', "WXYZ"},
            {'0', " "},
            {'*', ""}, // Backspace key
            {'#', ""} // Send key
        };
    }
}