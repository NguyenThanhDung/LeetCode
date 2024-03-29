using System.Text;

public class Problem067
{
    public Problem067()
    {
        Console.WriteLine(AddBinary("11", "1").Equals("100"));
        Console.WriteLine(AddBinary("1010", "1011").Equals("10101"));
        Console.WriteLine(AddBinary("1111", "1111").Equals("11110"));
    }

    public string AddBinary(string a, string b)
    {
        var r = new int[Math.Max(a.Length, b.Length) + 1];
        for (int i = a.Length - 1, j = b.Length - 1, k = 0; i >= 0 || j >= 0; i--, j--, k++)
        {
            int sum = CharToInt(TryToGet(a, i)) + CharToInt(TryToGet(b, j)) + r[k];
            r[k] = sum > 1 ? (sum - 2) : sum;
            r[k + 1] = sum > 1 ? 1 : 0;
        }
        return ArrayToString(r);
    }

    private char TryToGet(string s, int index)
    {
        return (index >= 0) ? s[index] : '0';
    }

    private int CharToInt(char c)
    {
        return c - '0';
    }

    private string ArrayToString(int[] nums)
    {
        var s = new StringBuilder();
        int i = nums[nums.Length - 1] == 0 ? nums.Length - 2 : nums.Length - 1;
        for (; i >= 0; i--)
        {
            s.Append(nums[i]);
        }
        return s.ToString();
    }
}

// a = "11010"
// b = "1011"
//
// i    j   a[i]    b[j]    sum=a[i]+b[j]+mem       k   r               sum>1?      mem
// 4    3   0       1       1                       0   [1,0,0,0,0,0]   false       0
// 3    2   1       1       2                       1   [1,1,0,0,0,0]   true        1
// 2    1   0       0       1                       2   [1,1,1,0,0,0]   false       0