using LongestIncrSubsequence.Core;

var finder = new LongestIncrSubsequenceFinder();

// If arguments provided, use them
if (args.Length > 0)
{
    string input = string.Join(" ", args);
    string result = finder.FindLongestIncrSubsequence(input);
    Console.WriteLine(result);
    return;
}


while (true)
{
    Console.WriteLine("Enter space-separated integers (or 'exit' to quit):");
    Console.Write("> ");

    string? input = Console.ReadLine();

    if (string.IsNullOrWhiteSpace(input))
    {
        Console.WriteLine("Input cannot be empty. Please try again.");
        Console.WriteLine();
        continue;
    }

    if (input.Equals("exit", StringComparison.OrdinalIgnoreCase))
    {
        Console.WriteLine("Exited!");
        break;
    }

    try
    {
        string result = finder.FindLongestIncrSubsequence(input);
        Console.WriteLine($"Result: {result}");
        Console.WriteLine();
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error: {ex.Message}");
        Console.WriteLine();
    }
}
