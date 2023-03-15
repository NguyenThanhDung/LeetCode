using System;
using System.Linq;

public class Problem001
{
    public Problem001()
    {
        Console.WriteLine(TwoSum(new int[] { 2, 7, 11, 15 }, 9).SequenceEqual(new int[] { 0, 1 }));
        Console.WriteLine(TwoSum(new int[] { 3, 2, 4 }, 6).SequenceEqual(new int[] { 1, 2 }));
        Console.WriteLine(TwoSum(new int[] { 3, 3 }, 6).SequenceEqual(new int[] { 0, 1 }));
    }


    public int[] TwoSum(int[] nums, int target)
    {
        return new int[2] { 0, 1 };
    }
}