using System;

namespace KeyPadParser
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Old Phone Pad Text Input Simulator");
            Console.WriteLine("=================================");
            Console.WriteLine("Enter your input (must end with #) or 'exit' to quit");
            Console.WriteLine("Example: 4433555 555666# -> HELLO");

            while (true)
            {
                Console.Write("\nInput: ");
                var input = Console.ReadLine();

                if (string.IsNullOrEmpty(input) || input.ToLower() == "exit")
                {
                    break;
                }

                try
                {
                    var result = OldPhonePad.ProcessInput(input);
                    Console.WriteLine($"Output: {result}");
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }

            Console.WriteLine("\nThank you for using Old Phone Pad!");
        }
    }
}