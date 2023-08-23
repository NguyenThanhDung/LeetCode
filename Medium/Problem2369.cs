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
            bool isValid = true;
            foreach (var length in possibleSubArrayLength)
            {
                var subArray = new int[length];
                Array.Copy(nums, currentIndex, subArray, 0, length);
                isValid = IsValid(subArray);
                if (!isValid)
                    break;
                currentIndex += length;
            }
            if (isValid)
                return true;
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

    private bool IsValid(int[] array)
    {
        if (array.Length == 2)
        {
            return array[0] == array[1];
        }
        else if (array.Length == 3)
        {
            if (array[0] == array[1] && array[0] == array[2])
                return true;
            else
                return (array[0] + 1) == array[1] && (array[1] + 1) == array[2];
        }
        else
        {
            return false;
        }
    }
}