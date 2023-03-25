public class Problem2423
{
    /*
    for all c in word do
    H{c} += 1

    sum = 0
    for all k in H do
        if H{k} != H[0] && H{k} != H[1]
            return false
        sum += H{k} - Min(H[0],H[1])
    return sum == 1
    */

    public Problem2423()
    {
        Console.WriteLine(EqualFrequency("abcc") == true);
        Console.WriteLine(EqualFrequency("aazz") == false);
        Console.WriteLine(EqualFrequency("abccc") == false);
        Console.WriteLine(EqualFrequency("abbcc") == false);
        Console.WriteLine(EqualFrequency("aabbbccc") == false);
        Console.WriteLine(EqualFrequency("aabcc") == false);
        Console.WriteLine(EqualFrequency("aaabbc") == false);
    }

    public bool EqualFrequency(string word)
    {
        if (word.Length < 2)
            return true;
        if (word.Length == 2)
            return word[0] == word[1];

        Dictionary<char, int> counter = new Dictionary<char, int>();
        foreach (char c in word)
        {
            if (counter.ContainsKey(c))
                counter[c]++;
            else
                counter.Add(c, 1);
        }

        int i = 0;
        int first = 0;
        int second = 0;
        foreach (char k in counter.Keys)
        {
            if (i == 0)
            {
                first = counter[k];
                i++;
            }
            else if (i == 1)
            {
                second = counter[k];
                i++;
            }
            else
            {
                break;
            }
        }

        int sum = 0;
        foreach (char k in counter.Keys)
        {
            if (counter[k] != first && counter[k] != second)
                return false;
            sum += counter[k] - (first < second ? first : second);
        }

        return sum == 1;
    }
}