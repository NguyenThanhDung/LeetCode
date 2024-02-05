// https://leetcode.com/problems/first-unique-character-in-a-string/
public class Problem387
{
    public Problem387()
    {
        Console.WriteLine(FirstUniqChar("leetcode") == 0);
        Console.WriteLine(FirstUniqChar("loveleetcode") == 2);
        Console.WriteLine(FirstUniqChar("aabb") == -1);
    }

    public int FirstUniqChar(string s)
    {
        int result = int.MaxValue;

        for(char c = 'a'; c <= 'z'; c++)
        {
            int firstIndex = s.IndexOf(c);
            if(firstIndex != -1 && s.LastIndexOf(c) == firstIndex)
            {
                if(firstIndex < result)
                {
                    result = firstIndex;
                }
            }
        }

        return result == int.MaxValue ? -1 : result;
    }
}