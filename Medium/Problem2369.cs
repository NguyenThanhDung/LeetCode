using System.Text;

public class Problem2369
{
    public Problem2369()
    {
        Console.WriteLine(ValidPartition(new int[] { 4, 4, 4, 5, 6 }) == true);
        Console.WriteLine(ValidPartition(new int[] { 1, 1, 1, 2 }) == false);
    }

    public bool ValidPartition(int[] nums)
    {
        var possibleSubArrayLengths = FindPossibleSubArrayLengths(nums.Length);
        foreach (var possibleSubArrayLength in possibleSubArrayLengths)
        {
            int currentIndex = 0;
            foreach (var length in possibleSubArrayLength)
            {
                var subArray = new int[length];
                Array.Copy(nums, currentIndex, subArray, 0, length);
                currentIndex += length;
            }
        }
        return false;
    }

    private IList<IList<int>> FindPossibleSubArrayLengths(int arrayLength)
    {
        var lengths = new List<IList<int>>();
        var currentLengths = new List<int>();
        FindPossibleSubArrayLengthsRecursively(arrayLength, lengths, currentLengths, 2);
        FindPossibleSubArrayLengthsRecursively(arrayLength, lengths, currentLengths, 3);
        return lengths;
    }

    private void FindPossibleSubArrayLengthsRecursively(int remaining, IList<IList<int>> lengths, IList<int> currentLengths, int size)
    {
        remaining -= size;
        if (remaining < 0)
            return;

        currentLengths.Add(size);
        if (remaining == 0)
        {
            var validLengths = new List<int>(currentLengths);
            lengths.Add(validLengths);
        }
        else
        {
            FindPossibleSubArrayLengthsRecursively(remaining, lengths, currentLengths, 2);
            FindPossibleSubArrayLengthsRecursively(remaining, lengths, currentLengths, 3);
        }
        currentLengths.RemoveAt(currentLengths.Count - 1);
    }
}