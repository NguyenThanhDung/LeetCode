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
            if (ValidPartition(GetRemainingArray(nums, 2)))
                return true;
            else
            {
                if (nums.Length == 2)
                    return false;
                if (IsSubArrayValid(nums, 3))
                    return ValidPartition(GetRemainingArray(nums, 3));
                else
                    return false;
            }
        }
        else
        {
            if (nums.Length == 2)
                return false;
            if (IsSubArrayValid(nums, 3))
                return ValidPartition(GetRemainingArray(nums, 3));
            else
                return false;
        }
    }

    private bool IsSubArrayValid(int[] array, int subArrayLength)
    {
        if(array.Length < subArrayLength)
            return false;
        if (subArrayLength == 2)
        {
            return array[0] == array[1];
        }
        else if (subArrayLength == 3)
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

    private int[] GetRemainingArray(int[] array, int offset)
    {
        if (array.Length < offset)
            return null;
        int[] remainingArray = new int[array.Length - offset];
        Array.Copy(array, offset, remainingArray, 0, remainingArray.Length);
        return remainingArray;
    }
}