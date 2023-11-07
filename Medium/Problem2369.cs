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
        if (IsSubArrayValid(nums, 2))
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
                if (IsSubArrayValid(nums, 3))
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
            if (IsSubArrayValid(nums, 3))
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

    public bool IsSubArrayValid(int[] array, int subArrayLength)
    {
        int[] subArray = new int[subArrayLength];
        Array.Copy(array, subArray, subArrayLength);
        if (subArray.Length == 2)
        {
            return subArray[0] == subArray[1];
        }
        else if (subArray.Length == 3)
        {
            if (subArray[0] == subArray[1] && subArray[0] == subArray[2])
                return true;
            else
                return (subArray[0] + 1) == subArray[1] && (subArray[1] + 1) == subArray[2];
        }
        else
        {
            return false;
        }
    }
}