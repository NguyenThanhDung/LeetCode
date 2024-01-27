using System.Text;

public class Problem2369
{
    public Problem2369()
    {
        Console.WriteLine(ValidPartition(new int[] { 4, 4, 4, 5, 6 }) == true);
        Console.WriteLine(ValidPartition(new int[] { 1, 1, 1, 2 }) == false);
        Console.WriteLine(ValidPartition(new int[] { 803201, 803201, 803201, 803201, 803202, 803203 }) == true);
    }

    enum ValidationStatus
    {
        NotCheck = 0,
        Valid,
        Invalid
    }

    public bool ValidPartition(int[] nums)
    {
        ValidationStatus[,] validation = new ValidationStatus[nums.Length, 2];
        return ValidPartitionRecursive(nums, 0, validation);
    }

    private bool ValidPartitionRecursive(int[] nums, int currentIndex, ValidationStatus[,] validation)
    {
        if ((nums.Length - currentIndex) == 0)
            return true;
        if ((nums.Length - currentIndex) == 1)
            return false;
        if (IsSubArrayValid(nums, currentIndex, 2, validation))
        {
            validation[currentIndex, 0] = ValidationStatus.Valid;
            if (ValidPartitionRecursive(nums, currentIndex + 2, validation))
                return true;
            else
            {
                if (nums.Length == 2)
                    return false;
                if (IsSubArrayValid(nums, currentIndex, 3, validation))
                {
                    validation[currentIndex, 1] = ValidationStatus.Valid;
                    return ValidPartitionRecursive(nums, currentIndex + 3, validation);
                }
                else
                {
                    validation[currentIndex, 1] = ValidationStatus.Invalid;
                    return false;
                }
            }
        }
        else
        {
            validation[currentIndex, 0] = ValidationStatus.Invalid;
            if (nums.Length == 2)
                return false;
            if (IsSubArrayValid(nums, currentIndex, 3, validation))
            {
                validation[currentIndex, 1] = ValidationStatus.Valid;
                return ValidPartitionRecursive(nums, currentIndex + 3, validation);
            }
            else
            {
                validation[currentIndex, 1] = ValidationStatus.Invalid;
                return false;
            }
        }
    }

    private bool IsSubArrayValid(int[] array, int currentIndex, int subArrayLength, ValidationStatus[,] validation)
    {
        if ((array.Length - currentIndex) < subArrayLength)
        {
            return false;
        }
        if (subArrayLength == 2)
        {
            return array[currentIndex] == array[currentIndex + 1];
        }
        else if (subArrayLength == 3)
        {
            if (array[currentIndex] == array[currentIndex + 1] && array[currentIndex] == array[currentIndex + 2])
                return true;
            else
                return (array[currentIndex] + 1) == array[currentIndex + 1] && (array[currentIndex + 1] + 1) == array[currentIndex + 2];
        }
        else
        {
            return false;
        }
    }
}