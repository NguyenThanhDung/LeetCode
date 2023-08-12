public class Problem238
{
    public Problem238()
    {
        Console.WriteLine(Testing.CompareArrays(ProductExceptSelf(new int[] { 1, 2, 3, 4 }), new int[] { 24, 12, 8, 6 }));
        Console.WriteLine(Testing.CompareArrays(ProductExceptSelf(new int[] { -1, 1, 0, -3, 3 }), new int[] { 0, 0, 9, 0, 0 }));
    }

    public int[] ProductExceptSelf(int[] nums)
    {
        int[] answer = new int[nums.Length];

        int product = 1;
        int zeroCount = 0;
        foreach (var n in nums)
        {
            if (n == 0)
                zeroCount++;
            else
                product *= n;
        }

        for (int i = 0; i < answer.Length; i++)
        {
            if (zeroCount >= 2)
                answer[i] = 0;
            else if (zeroCount == 1)
            {
                if (nums[i] == 0)
                    answer[i] = product;
                else
                    answer[i] = 0;
            }
            else
            {
                answer[i] = product / nums[i];
            }
        }

        return answer;
    }
}