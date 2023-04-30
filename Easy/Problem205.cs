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

        Queue<char> map1 = new Queue<char>();
        Dictionary<char, List<int>> dict1 = new Dictionary<char, List<int>>();
        for (int i = 0; i < s.Length; i++)
        {
            map1.Enqueue(s[i]);
            if (dict1.ContainsKey(s[i]) == false)
                dict1[s[i]] = new List<int>();
            dict1[s[i]].Add(i);
        }

        Queue<char> map2 = new Queue<char>();
        Dictionary<char, List<int>> dict2 = new Dictionary<char, List<int>>();
        for (int i = 0; i < t.Length; i++)
        {
            map2.Enqueue(t[i]);
            if (dict2.ContainsKey(t[i]) == false)
                dict2[t[i]] = new List<int>();
            dict2[t[i]].Add(i);
        }

        if (map1.Count != map2.Count)
            return false;

        while (map1.Count > 0)
        {
            char c1 = map1.Dequeue();
            char c2 = map2.Dequeue();

            List<int> indexes1 = dict1[c1];
            List<int> indexes2 = dict2[c2];

            if (indexes1.Count != indexes2.Count)
                return false;

            for (int i = 0; i < indexes1.Count; i++)
            {
                if (indexes1[i] != indexes2[i])
                    return false;
            }
        }

        return true;
    }
}