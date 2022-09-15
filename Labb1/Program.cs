
using System.Numerics;
bool isProgramRunning = true;
BigInteger sum = 0;

do
{
    sum = 0;
    SequenceFinder();

    Console.WriteLine();
    Console.WriteLine("Press ESC to Quit or the Any key to enter a new sequence.");

    if (Console.ReadKey(true).Key == ConsoleKey.Escape) isProgramRunning = false;

    Console.Clear();
}
while (isProgramRunning);


void SequenceFinder()
{
    Console.WriteLine("Welcome to my Sequence Finder!");
    string userInput = RequestUserInput();
    Console.Clear();
    CalculateSequence(userInput);
    Console.WriteLine($"Total value of colored numbers {sum}");

}

string RequestUserInput()
{
    string userInput;
    bool isValidInput;
    do
    {
        Console.WriteLine("Insert String To Sequence");
        userInput = Console.ReadLine();
        isValidInput = !string.IsNullOrEmpty(userInput);
        if (!isValidInput)
        {
            Console.WriteLine("Need more to work with");
        }
    }
    while (!isValidInput);
    return userInput;

}

void CalculateSequence(string userInput)
{
    for (int i = 0; i < userInput.Length; i++)
    {
        int numberCounter = 0;

        for (int j = i + 1; j < userInput.Length; j++)
        {
            if (char.IsDigit(userInput[j]))
            {
                numberCounter++;

                if (userInput[i] == userInput[j])
                {
                    ColorIntervall(userInput, i, j, numberCounter);
                    NumberCounter(userInput, i, numberCounter);
                    break;
                }
            }
            else
            {
                break;
            }
        }
    }
}


void ColorIntervall(string userInput, int startIndex, int stopIndex, int numberCounter)
{

    Console.ForegroundColor = ConsoleColor.Gray;
    Console.Write(userInput[..startIndex]);
    Console.ForegroundColor = ConsoleColor.Red;
    Console.Write(userInput.Substring(startIndex, numberCounter + 1));
    Console.ForegroundColor = ConsoleColor.Gray;
    Console.Write(userInput[(stopIndex + 1)..]);
    Console.WriteLine();

}

void NumberCounter(string userInput, int startIndex, int numberCounter)
{
    BigInteger coloredNumber;
    coloredNumber = BigInteger.Parse(userInput.Substring(startIndex, numberCounter + 1));
    sum += coloredNumber;

}

