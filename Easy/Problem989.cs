using System;
using System.Linq;

public class Problem989
{
    public Problem989()
    {
        Console.WriteLine(maxLength(new int[] { 1, 2, 0, 0 }, 34) == 4);
        Console.WriteLine(maxLength(new int[] { 2, 7, 4 }, 181) == 3);
        Console.WriteLine(maxLength(new int[] { 2, 1, 5 }, 806) == 3);
        Console.WriteLine(maxLength(new int[] { 1, 2, 1, 5 }, 806) == 4);
        Console.WriteLine(maxLength(new int[] { 2, 1, 5 }, 8064) == 4);

        Console.WriteLine(compareArray(numberToArray(34, 2), new int[] { 3, 4 }));
        Console.WriteLine(compareArray(numberToArray(181, 3), new int[] { 1, 8, 1 }));
        Console.WriteLine(compareArray(numberToArray(806, 3), new int[] { 8, 0, 6 }));
        Console.WriteLine(compareArray(numberToArray(1806, 4), new int[] { 1, 8, 0, 6 }));

        // Console.WriteLine(Enumerable.SequenceEqual(AddToArrayForm(new int[] { 1, 2, 0, 0 }, 34), new int[] { 1, 2, 3, 4 }));
        // Console.WriteLine(Enumerable.SequenceEqual(AddToArrayForm(new int[] { 2, 7, 4 }, 181), new int[] { 4, 5, 5 }));
        // Console.WriteLine(Enumerable.SequenceEqual(AddToArrayForm(new int[] { 2, 1, 5 }, 806), new int[] { 1, 0, 2, 1 }));
    }

    private bool compareArray(int[] a1, int[] a2)
    {
        if (a1.Length != a2.Length)
            return false;
        for (int i = 0; i < a1.Length; i++)
        {
            if (a1[i] != a2[i])
                return false;
        }
        return true;
    }

    private int maxLength(int[] num, int k)
    {
        int kLength = 1;
        while ((k / 10) > 0)
        {
            k /= 10;
            kLength++;
        }
        return (num.Length > kLength) ? num.Length : kLength;
    }

    private int[] numberToArray(int k, int arrayLength)
    {
        int[] kArray = new int[arrayLength];
        for(int i = arrayLength - 1; k > 0 && i >= 0; k /= 10, i--)
            kArray[i] = k % 10;
        return kArray;
    }

    public IList<int> AddToArrayForm(int[] num, int k)
    {
        return new int[] { 1, 2, 3, 4 };
    }
}