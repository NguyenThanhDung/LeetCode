public class Problem2423
{
    /*
    for all c in word do
        charCounters{c} += 1
    
    if count of charCounters == 1
        return true

    if count of charCounters == 2
        return Abs(H[0] - H[1]) == 1

    for all (key, value) of charCounters do
        freqCounters{value} += 1

    if count of freqCounters == 1
        return freqCounters.Keys[0] == 1

    if count of freqCounters == 2
        if freqCounters[0].Value == 1 or freqCounters[1].Value == 1
            if freqCounters[0].Value == 1
                if freqCounters[0].Key == 1
                    return true
                else
                    return Abs(freqCounters[0].Key - freqCounters[1].Key) == 1
            if freqCounters[1].Value == 1
                if freqCounters[1].Key == 1
                    return true
                else
                    return Abs(freqCounters[0].Key - freqCounters[1].Key) == 1
        else
            return false

    return false
    */

    public Problem2423()
    {
        Console.WriteLine(EqualFrequency("aaa") == true);       // {a:3}                -> NumberOfCharTypes == 1                   -> true
        Console.WriteLine(EqualFrequency("aazzz") == true);     // {a:2, z:3}           -> NumberOfCharTypes == 2 && Abs(count1 - count2) == 1          -> true
        Console.WriteLine(EqualFrequency("aazz") == false);     // {a:2, z:2}           -> NumberOfCharTypes == 2 && Abs(count1 - count2) != 1          -> false
        Console.WriteLine(EqualFrequency("bac") == true);       // {a:1, b:1, c:1}      -> {1:3}            -> numOfFrequencies: 1  -> Frequency == 1   -> true
        Console.WriteLine(EqualFrequency("aabbcc") == false);   // {a:2, b:2, c:2}      -> {2:3}            -> numOfFrequencies: 1  -> Frequency > 1    -> false
        Console.WriteLine(EqualFrequency("abbcc") == true);     // {a:1, b:2, c:2}      -> {1:1, 2:2}       -> numOfFrequencies: 2  -> There is one count == 1  -> Its frequency == 1   -> true
        Console.WriteLine(EqualFrequency("abcc") == true);      // {a:1, b:1, c:2}      -> {1:2, 2:1}       -> numOfFrequencies: 2  -> There is one count == 1  -> Its frequency > 1    -> Abs(freq1 - freq2) == 1  -> true
        Console.WriteLine(EqualFrequency("abccc") == false);    // {a:1, b:1, c:3}      -> {1:2, 3:1}       -> numOfFrequencies: 2  -> There is one count == 1  -> Its frequency > 1    -> Abs(freq1 - freq2) > 1   -> false
        Console.WriteLine(EqualFrequency("abccdd") == false);   // {a:1, b:1, c:2, d:2} -> {1:2, 2:2}       -> numOfFrequencies: 2  -> There is no count == 1   -> false
        Console.WriteLine(EqualFrequency("abcccddd") == false); // {a:1, b:1, c:3, d:3} -> {1:2, 3:2}       -> numOfFrequencies: 2  -> There is no count == 1   -> false
        Console.WriteLine(EqualFrequency("babbdd") == false);   // {a:1, b:3, d:2}      -> {1:1, 3:1, 2:1}  -> numOfFrequencies: 3  -> false
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

        if (counter.Count == 1)
            return true;

        if (counter.Count == 2)
            return Math.Abs(counter.ElementAt(0).Value - counter.ElementAt(1).Value) == 1;

        int min = Math.Min(counter.ElementAt(0).Value, counter.ElementAt(1).Value);
        int sum = 0;
        int numOfSingleChar = 0;
        foreach (char k in counter.Keys)
        {
            sum += counter[k] - min;
            if (counter[k] == 1)
                numOfSingleChar++;
        }

        if (sum == 1)
            return true;
        else if (sum == 0 && counter.ElementAt(0).Value == 1)
            return true;
        else if (sum > 1 && numOfSingleChar == 1)
            return true;
        else
            return false;
    }
}