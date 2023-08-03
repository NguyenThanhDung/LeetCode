public class Problem412
{
    public Problem412()
    {
        Console.WriteLine(Testing.CompareLists(FizzBuzz(3), (new string[] { "1", "2", "Fizz" }).ToList()));
        Console.WriteLine(Testing.CompareLists(FizzBuzz(5), (new string[] { "1", "2", "Fizz", "4", "Buzz" }).ToList()));
        Console.WriteLine(Testing.CompareLists(FizzBuzz(15), (new string[] { "1", "2", "Fizz", "4", "Buzz", "Fizz", "7", "8", "Fizz", "Buzz", "11", "Fizz", "13", "14", "FizzBuzz" }).ToList()));
    }

    public IList<string> FizzBuzz(int n)
    {
        IList<string> answer = new List<string>();
        for (int i = 1; i <= n; i++)
        {
            if (i % 3 == 0 && i % 5 == 0)
                answer.Add("FizzBuzz");
            else if (i % 3 == 0)
                answer.Add("Fizz");
            else if (i % 5 == 0)
                answer.Add("Buzz");
            else
                answer.Add(i.ToString());
        }
        return answer;
    }
}