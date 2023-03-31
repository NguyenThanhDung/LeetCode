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
    numOfSingleChar = 0
    for all k in H do
        sum += H{k} - min
        if H{k} == 1
            numOfSingleChar++
    if sum == 1
        return true
    else if sum == 0 and H[0] == 1
        return true
    else if sum > 1 and numOfSingleChar == 1
        return true
    else
        return false
    */

    public Problem2423()
    {
        Console.WriteLine(EqualFrequency("abcc") == true);      // {a:1, b:1, c:2}  -> {1:2, 2:1}       -> numOfFrequencies: 2
        Console.WriteLine(EqualFrequency("aazz") == false);     // {a:2, z:2}       -> {2:2}            -> numOfFrequencies: 1  -> Frequency > 1    -> false
        Console.WriteLine(EqualFrequency("abbcc") == true);     // {a:1, b:2, c:2}  -> {1:1, 2:2}       -> numOfFrequencies: 2  -> Contains frequency 1 and its quality is 1    -> true
        Console.WriteLine(EqualFrequency("bac") == true);       // {a:1, b:1, c:1}  -> {1:3}            -> numOfFrequencies: 1  -> Frequency == 1   -> true
        Console.WriteLine(EqualFrequency("babbdd") == false);   // {a:1, b:3, d:2}  -> {1:1, 3:1, 2:1}  -> numOfFrequencies: 3 -> false
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