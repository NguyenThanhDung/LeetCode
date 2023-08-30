public class Problem066
{
    public Problem066()
    {
        Console.WriteLine(Testing.CompareArrays(PlusOne(new int[] { 1, 2, 3 }), new int[] { 1, 2, 4 }));
        Console.WriteLine(Testing.CompareArrays(PlusOne(new int[] { 4, 3, 2, 1 }), new int[] { 4, 3, 2, 2 }));
        Console.WriteLine(Testing.CompareArrays(PlusOne(new int[] { 9 }), new int[] { 1, 0 }));
    }

    public int[] PlusOne(int[] digits)
    {
        bool shouldIncrease = true;
        bool isLastLeftDigitExceeded = false;
        for (int i = digits.Length - 1; i >= 0; i--)
        {
            if (shouldIncrease)
            {
                digits[i]++;
                if (digits[i] > 9)
                {
                    digits[i] = 0;
                    shouldIncrease = true;
                    if (i == 0)
                        isLastLeftDigitExceeded = true;
                }
                else
                {
                    shouldIncrease = false;
                }
            }
        }
        if (isLastLeftDigitExceeded)
        {
            int[] newDigits = new int[digits.Length + 1];
            newDigits[0] = 1;
            for (int i = 0; i < digits.Length; i++)
                newDigits[i + 1] = digits[i];
            return newDigits;
        }
        else
        {
            return digits;
        }
    }
}
