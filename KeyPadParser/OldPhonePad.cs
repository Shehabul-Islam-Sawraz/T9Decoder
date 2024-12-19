using System;
using System.Text;
using KeyPadParser.Models;
using KeyPadParser.Services;

namespace KeyPadParser
{
    /// <summary>
    /// Main class for converting old phone keypad inputs into text.
    /// </summary>
    public class OldPhonePad
    {
        /// <summary>
        /// Converts a sequence of keypad inputs into the corresponding text output.
        /// </summary>
        /// <param name="input">The input string representing keypad presses.</param>
        /// <returns>The decoded text message.</returns>
        /// <exception cref="ArgumentException">Thrown when input is invalid.</exception>
        public static string ProcessInput(string input)
        {
            InputProcessor.ValidateInput(input);

            var result = new StringBuilder();
            KeypadInput currentInput = null;

            for (int i = 0; i < input.Length; i++)
            {
                var key = input[i];

                // Handle whitespace
                if (char.IsWhiteSpace(key))
                {
                    if (currentInput != null)
                    {
                        result.Append(InputProcessor.ProcessKeyPress(currentInput));
                        currentInput = null;
                    }
                    continue;
                }

                // Handle send key
                if (key == '#')
                {
                    if (currentInput != null)
                    {
                        result.Append(InputProcessor.ProcessKeyPress(currentInput));
                    }
                    break;
                }

                // Handle backspace
                if (key == '*')
                {
                    if (currentInput != null)
                    {
                        // If we have a current input, just discard it
                        currentInput = null;
                    }
                    else if (result.Length > 0)
                    {
                        // If no current input but we have characters in result, remove the last one
                        result.Length--;
                    }
                    continue;
                }

                // Handle regular key press
                if (currentInput == null || currentInput.Key != key)
                {
                    if (currentInput != null)
                    {
                        result.Append(InputProcessor.ProcessKeyPress(currentInput));
                    }
                    currentInput = new KeypadInput(key);
                }
                else
                {
                    currentInput.IncrementPressCount();
                }
            }

            return result.ToString();
        }
    }
}