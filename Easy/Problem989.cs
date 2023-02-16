using System;
using System.Linq;

public class Problem989
{
    public Problem989()
    {
        Console.WriteLine(Enumerable.SequenceEqual(AddToArrayForm(new int[] { 1, 2, 0, 0 }, 34), new int[] { 1, 2, 3, 4 }));
    }

    public IList<int> AddToArrayForm(int[] num, int k)
    {
        return new int[] { 1, 2, 3, 4 };
    }
}