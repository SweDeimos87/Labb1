
#pragma warning disable CS8602 // Dereference of a possibly null reference.
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.

//29535123p4872348759764572364

using System.Numerics;
bool isProgramRunning = true;

do
{
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
    RequestUserInput();

}

string RequestUserInput()
{
    string userInput;
    bool isValidInput;
    BigInteger sum = 0;
    do
    {
        Console.WriteLine("Insert String To Sequence");
        userInput = Console.ReadLine();
        for (int i = 0; i < userInput.Length; i++)
        {
            int numberCounter = 0;

            for (int j = i + 1; j < userInput.Length; j++)
                if (int.TryParse(userInput[j].ToString(), out int _))
                {
                    numberCounter++;

                    if (userInput[i] == userInput[j])
                    {
                        BigInteger coloredNumber;
                        coloredNumber = BigInteger.Parse(userInput.Substring(i, numberCounter + 1));
                        sum += coloredNumber;
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.Write(userInput[..i]);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(userInput.Substring(i, numberCounter + 1));
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.Write(userInput[(j + 1)..]);
                        Console.WriteLine();
                        break;
                    }
                }
                else
                {
                    break;
                }

        }
        Console.WriteLine($"Total value of colored numbers {sum}");

        isValidInput = !string.IsNullOrEmpty(userInput);
        if (!isValidInput)
        {
            Console.WriteLine("You have not entered a valid input please try again..");
        }
    }
    while (!isValidInput);
    return userInput;
}





