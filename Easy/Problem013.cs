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
        int lastNumber = -1;
        int currentNumber = -1;
        for(int i = 0; i < s.Length; i++)
        {
            currentNumber = SymbolToInt(s[i]);
            if(lastNumber < 0)
            {
                lastNumber = currentNumber;
            }
            else
            {
                if(lastNumber < currentNumber)
                {
                    result += currentNumber - lastNumber;
                    lastNumber = -1;
                    currentNumber = -1;
                }
                else
                {
                    result += lastNumber;
                    lastNumber = currentNumber;
                }
            }
        }
        if(currentNumber > 0)
            result += currentNumber;
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