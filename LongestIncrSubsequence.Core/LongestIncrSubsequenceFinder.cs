namespace LongestIncrSubsequence.Core;

/// <summary>
/// Finds the Longest Increasing Subsequence (LIS) in a sequence of integers.
/// </summary>
public class LongestIncrSubsequenceFinder
{
    /// <summary>
    /// Finds the longest increasing subsequence from a space-separated string of integers.
    /// If multiple sequences of the same length exist, returns the earliest one.
    /// </summary>
    /// <param name="input">Space-separated integers</param>
    /// <returns>Space-separated integers representing the LIS</returns>
    public string FindLongestIncrSubsequence(string input)
    {
        if (string.IsNullOrWhiteSpace(input))
        {
            return string.Empty;
        }

        var numbers = input.Split(' ', System.StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        if (numbers.Length == 0)
        {
            return string.Empty;
        }

        if (numbers.Length == 1)
        {
            return numbers[0].ToString();
        }

        var lis = this.ComputeLargestIncrSubsequence(numbers);
        return string.Join(" ", lis);
    }

    /// <summary>
    /// Computes the longest contiguous increasing subarray.
    /// If multiple subarrays of the same length exist, returns the earliest one.
    /// </summary>
    /// <param name="numbers">Array of integers to process.</param>
    /// <returns>Array representing the longest contiguous increasing subarray.</returns>
    private int[] ComputeLargestIncrSubsequence(int[] numbers)
    {
        int n = numbers.Length;

        if (n == 0)
        {
            return Array.Empty<int>();
        }

        int maxLength = 1;
        int maxStartIndex = 0;
        int currentLength = 1;
        int currentStartIndex = 0;

        // Find the longest contiguous increasing subarray
        for (int i = 1; i < n; i++)
        {
            if (numbers[i] > numbers[i - 1])
            {
                // Continue the current increasing sequence
                currentLength++;
            }
            else
            {
                // Ended current sequence, check if it is the longest
                if (currentLength > maxLength)
                {
                    maxLength = currentLength;
                    maxStartIndex = currentStartIndex;
                }

                // Start a new sequence
                currentStartIndex = i;
                currentLength = 1;
            }
        }

        // Don't forget to check the last sequence
        if (currentLength > maxLength)
        {
            maxLength = currentLength;
            maxStartIndex = currentStartIndex;
        }

        // Extract and return the longest subarray
        var result = new int[maxLength];
        Array.Copy(numbers, maxStartIndex, result, 0, maxLength);
        return result;
    }
}
