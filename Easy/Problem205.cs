public class Problem205
{
    public Problem205()
    {
        Console.WriteLine(IsIsomorphic("egg", "add") == true);
        Console.WriteLine(IsIsomorphic("foo", "bar") == false);
        Console.WriteLine(IsIsomorphic("paper", "title") == true);
    }

    public bool IsIsomorphic(string s, string t)
    {
        if (s.Length != t.Length)
            return false;

        List<char> list1 = new List<char>();
        Dictionary<char, List<int>> dict1 = new Dictionary<char, List<int>>();
        for (int i = 0; i < s.Length; i++)
        {
            if (list1.Contains(s[i]) == false)
            {
                list1.Add(s[i]);
                if (dict1.ContainsKey(s[i]) == false)
                    dict1[s[i]] = new List<int>();
                dict1[s[i]].Add(i);
            }
        }

        List<char> list2 = new List<char>();
        Dictionary<char, List<int>> dict2 = new Dictionary<char, List<int>>();
        for (int i = 0; i < t.Length; i++)
        {
            if (list2.Contains(t[i]) == false)
            {
                list2.Add(t[i]);
                if (dict2.ContainsKey(t[i]) == false)
                    dict2[t[i]] = new List<int>();
                dict2[t[i]].Add(i);
            }
        }

        if (list1.Count != list2.Count)
            return false;

        for (int i = 0; i < list1.Count; i++)
        {
            char c1 = list1[i];
            char c2 = list2[i];

            List<int> indexes1 = dict1[c1];
            List<int> indexes2 = dict2[c2];

            if (indexes1.Count != indexes2.Count)
                return false;

            for (int j = 0; j < indexes1.Count; j++)
            {
                if (indexes1[j] != indexes2[j])
                    return false;
            }
        }

        return true;
    }
}