public class Problem013
{
    public Problem013()
    {
        Console.WriteLine(RomanToInt("III") == 3);
        Console.WriteLine(RomanToInt("LVIII") == 58);
        Console.WriteLine(RomanToInt("MCMXCIV") == 1994);
    }

    public int RomanToInt(string s)
    {
        int result = 0;
        for(int i = 0; i < s.Length; i++)
        {
            int currentNumber = SymbolToInt(s[i]);
            if(i < s.Length - 1)
            {
                int nextNumber = SymbolToInt(s[i + 1]);
                if(currentNumber < nextNumber)
                    result -= currentNumber;
                else
                    result += currentNumber;
            }
            else
            {
                result += currentNumber;
            }
        }
        return result;
    }

    private int SymbolToInt(char c)
    {
        switch (c)
        {
            case 'I':
                return 1;
            case 'V':
                return 5;
            case 'X':
                return 10;
            case 'L':
                return 50;
            case 'C':
                return 100;
            case 'D':
                return 500;
            case 'M':
                return 1000;
            default:
                return 0;
        }
    }
}