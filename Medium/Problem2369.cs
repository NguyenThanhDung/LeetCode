using System.Text;

public class Problem2369
{
    public Problem2369()
    {
        Console.WriteLine(ValidPartition(new int[] { 4, 4, 4, 5, 6 }) == true);
        Console.WriteLine(ValidPartition(new int[] { 1, 1, 1, 2 }) == false);
        Console.WriteLine(ValidPartition(new int[] { 803201, 803201, 803201, 803201, 803202, 803203 }) == true);
    }

    public bool ValidPartition(int[] nums)
    {
        if (nums.Length == 0)
            return true;
        if (nums.Length == 1)
            return false;
        int[] sub = new int[2];
        Array.Copy(nums, sub, sub.Length);
        if (IsSubArrayValid(sub))
        {
            int[] remaining = new int[nums.Length - 2];
            Array.Copy(nums, 2, remaining, 0, remaining.Length);
            if (ValidPartition(remaining))
            {
                return true;
            }
            else
            {
                if (nums.Length == 2)
                    return false;
                sub = new int[3];
                Array.Copy(nums, sub, sub.Length);
                if (IsSubArrayValid(sub))
                {
                    remaining = new int[nums.Length - 3];
                    Array.Copy(nums, 3, remaining, 0, remaining.Length);
                    return ValidPartition(remaining);
                }
                else
                {
                    return false;
                }
            }
        }
        else
        {
            if (nums.Length == 2)
                return false;
            sub = new int[3];
            Array.Copy(nums, sub, sub.Length);
            if (IsSubArrayValid(sub))
            {
                int[] remaining = new int[nums.Length - 3];
                Array.Copy(nums, 3, remaining, 0, remaining.Length);
                return ValidPartition(remaining);
            }
            else
            {
                return false;
            }
        }
    }

    public bool IsSubArrayValid(int[] array)
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