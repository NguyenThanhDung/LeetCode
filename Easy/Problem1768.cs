using System.Text;

public class Problem1768
{
    public Problem1768()
    {
        Console.WriteLine(MergeAlternately("abc", "pqr").Equals("apbqcr"));
        Console.WriteLine(MergeAlternately("ab", "pqrs").Equals("apbqrs"));
    }

    public string MergeAlternately(string word1, string word2)
    {
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < word1.Length || i < word2.Length; i++)
        {
            if (i < word1.Length)
                sb.Append(word1[i]);
            if (i < word2.Length)
                sb.Append(word2[i]);
        }
        return sb.ToString();
    }
}

// word1 = "abc"    
// word2 = "pqr"
//
// i    word1[i]    word2[j]    result
// 0    a           p           ap
// 1    b           q           qpbq
// 2    c           r           qpbqcr
//
// word1 = "ab"    
// word2 = "pqrs"
//
// i    word1[i]    word2[j]    result
// 0    a           p           ap
// 1    b           q           apbq
// 2    null                    apbqrs