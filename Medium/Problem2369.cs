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
        bool[] validations = new bool[nums.Length + 1];
        validations[0] = true;
        validations[2] = nums[1] == nums[0];
        for (int i = 3; i <= nums.Length; i++)
        {
            validations[i] = (validations[i - 2] && nums[i - 2] == nums[i - 1]) ||
                (validations[i - 3] && ((nums[i - 3] == nums[i - 2] && nums[i - 2] == nums[i - 1]) ||
                (nums[i - 3] + 1 == nums[i - 2] && nums[i - 2] + 1 == nums[i - 1])));
        }
        return validations[nums.Length];
    }
}