public class Problem014
{
    public Problem014()
    {
        Console.WriteLine(LongestCommonPrefix(new string[] { "flower", "flow", "flight" }).Equals(new string("fl")));
        Console.WriteLine(LongestCommonPrefix(new string[] { "dog", "racecar", "car" }).Equals(new string("")));
        Console.WriteLine(LongestCommonPrefix(new string[] { "ab", "a"}).Equals(new string("a")));
    }

    public string LongestCommonPrefix(string[] strs)
    {
        int commonLength = 0;
        for (int i = 0; i < strs[0].Length; i++)
        {
            bool isDifferent = false;
            for (int j = 1; j < strs.Length; j++)
            {
                if (i == strs[j].Length || strs[0][i] != strs[j][i])
                {
                    isDifferent = true;
                    break;
                }
            }
            if (isDifferent)
                break;
            else
                commonLength++;
        }
        return strs[0].Substring(0, commonLength);
    }
}