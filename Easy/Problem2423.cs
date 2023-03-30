public class Problem2423
{
    /*
    for all c in word do
        H{c} += 1
    
    if num of key in H == 1
        return true

    if num of key in H == 2
        return Abs(H[0] - H[1]) == 1

    min = Min(H[0], H[1])
    sum = 0
    for all k in H do
        sum += H{k} - min
    if sum == 1
        return true
    else if sum == 0 and H[0] == 1
        return true
    else
        return false
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
        Console.WriteLine(EqualFrequency("bac") == true);
    }

    public bool EqualFrequency(string word)
    {
        if (word.Length < 2)
            return true;

        Dictionary<char, int> counter = new Dictionary<char, int>();
        foreach (char c in word)
        {
            if (counter.ContainsKey(c))
                counter[c]++;
            else
                counter.Add(c, 1);
        }

        if(counter.Count == 1)
            return true;

        if(counter.Count == 2)
            return Math.Abs(counter.ElementAt(0).Value - counter.ElementAt(1).Value) == 1;

        int min = Math.Min(counter.ElementAt(0).Value, counter.ElementAt(1).Value);
        int sum = 0;
        foreach (char k in counter.Keys)
            sum += counter[k] - min;
        
        if(sum == 1)
            return true;
        else if (sum == 0 && counter.ElementAt(0).Value == 1)
            return true;
        else
            return false;
    }
}