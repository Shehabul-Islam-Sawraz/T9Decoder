# Old Phone Pad Challenge

This implementation provides a solution for converting old phone keypad inputs into text output, simulating the behavior of traditional mobile phone text input systems.

## Setup and Installation

1. Clone the repository:
```bash
git clone https://github.com/Shehabul-Islam-Sawraz/T9Decoder.git
cd T9Decoder
```

2. Build the project:
```bash
dotnet build
```

3. Run the application:
```bash
cd KeyPadParser
dotnet run
```

## Running Tests

Run all tests from the root project folder:
```bash
dotnet test Tests
```

Run specific test categories:
```bash
dotnet test Tests --filter TestCategory=BasicTests
dotnet test Tests --filter TestCategory=EdgeCaseTests
dotnet test Tests --filter TestCategory=ErrorTests
```

## Features

- Converts numeric key sequences into corresponding text output
- Handles multiple presses of the same key to cycle through letters
- Supports spaces, special characters, and timing separations
- Includes backspace functionality using the `*` key
- Comprehensive unit test coverage

## Key Mappings

```
1: &'(
2: ABC
3: DEF
4: GHI
5: JKL
6: MNO
7: PQRS
8: TUV
9: WXYZ
0: [space]
*: [backspace]
#: [send]
```

## API Documentation

### OldPhonePad Class
```csharp
public class OldPhonePad
{
    public static string ProcessInput(string input)
}
```
Main class responsible for converting keypad inputs to text.
- **ProcessInput**: Converts a sequence of keypad inputs into text
  - Parameters: `input` (string) - The keypad input sequence
  - Returns: The decoded text message
  - Throws: `ArgumentException` for invalid inputs

### KeypadInput Class
```csharp
public class KeypadInput
{
    public char Key { get; }
    public int PressCount { get; private set; }
    
    public void IncrementPressCount()
    public void Reset()
}
```
Represents a single keypad input with its press count.
- **IncrementPressCount**: Increases the press count for repeated key presses
- **Reset**: Resets the press count to 1

### InputProcessor Class
```csharp
public class InputProcessor
{
    public static char ProcessKeyPress(KeypadInput input)
    public static void ValidateInput(string input)
}
```
Handles input validation and processing.
- **ProcessKeyPress**: Converts a keypad input into its corresponding character
- **ValidateInput**: Validates the input string for basic requirements

### KeypadConfiguration Class
```csharp
public static class KeypadConfiguration
{
    public static readonly IReadOnlyDictionary<char, string> KeyMappings
}
```
Provides configuration for keypad mappings.
- **KeyMappings**: Read-only dictionary mapping keys to their characters

## Flow Diagrams

### Input Processing Flow
```
[User Input] → [Input Validation] → [Process Each Key]
                                        ↓
           [Handle Backspace] ← [Current Input] → [Process Character]
                                        ↓
                                  [Final Output]
```

### Key Press Processing Flow
```
[Key Press] → [Same as Previous?] → [Yes] → [Increment Count]
                     ↓
                    [No]
                     ↓
            [Process Previous] → [Start New Input]
```

## Usage

```csharp
// Basic usage
string result = OldPhonePad.ProcessInput("4433555 555666#"); // Returns "HELLO"

// Using backspace
string result = OldPhonePad.ProcessInput("4433*33555 555666#"); // Returns "HELLO"

// Using spaces for timing separation
string result = OldPhonePad.ProcessInput("8 88777444666*664#"); // Returns "TURING"
```

## Design Decisions

1. **Single Responsibility Principle**: Each class has one responsibility:
   - `KeypadConfiguration`: Manages key mappings
   - `InputProcessor`: Handles input validation and processing
   - `KeypadInput`: Represents a single keypad input state
   - `OldPhonePad`: Main controller class

2. **Immutability**: The key mappings are stored in a readonly dictionary to prevent modification.

3. **Error Handling**: Comprehensive input validation with meaningful error messages.

4. **Extensibility**: The design allows for easy modification of key mappings or addition of new features.

5. **Testability**: The implementation is thoroughly tested with unit tests covering various scenarios.

## Input Rules

- Input must end with the send key (`#`)
- Spaces are used for timing separation when typing multiple characters from the same key
- Multiple presses of the same key cycle through available characters
- The `*` key acts as backspace, removing the last entered character
- The `#` key sends the message

## Examples

```
"33#" → "E"
"227*#" → "B"
"4433555 555666#" → "HELLO"
"8 88777444666*664#" → "TURING"
"4433*33555 555666#" → "HELLO" (using backspace)
```

## Error Handling

The implementation throws **`ArgumentException`** for:
- Null or empty input
- Input without a send key (`#`)
- Invalid key presses