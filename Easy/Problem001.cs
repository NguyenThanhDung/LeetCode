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
        int[] result = new int[] { -1, -1 };
        for (int i = 0; i < nums.Length - 1; i++)
        {
            for (int j = i + 1; j < nums.Length; j++)
            {
                if (nums[i] + nums[j] == target)
                {
                    result[0] = i;
                    result[1] = j;
                    return result;
                }
            }
        }
        return result;
    }
}