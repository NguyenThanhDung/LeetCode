using System.IO;

public class Problem1300
{
    public Problem1300()
    {
        Console.WriteLine(FindBestValue2(new int[] { 4, 9, 3 }, 10) == 3);
        Console.WriteLine(FindBestValue2(new int[] { 2, 3, 5 }, 10) == 5);
        Console.WriteLine(FindBestValue2(new int[] { 60864, 25176, 27249, 21296, 20204 }, 56803) == 11361);

        Input input = new Input("Medium", "Input1300.txt");
        DateTime start = DateTime.Now;
        Console.WriteLine(FindBestValue2(input.arr, input.target) == 4);
        Console.WriteLine(DateTime.Now - start);
    }

    private class Input
    {
        public int[] arr;
        public int target;

        public Input(string level, string filename)
        {
            string path = Path.Join(Directory.GetCurrentDirectory(), level, filename);
            string[] lines = File.ReadAllLines(path);

            string[] arrStr = lines[0].Replace("[", "").Replace("]", "").Split(",");
            arr = new int[arrStr.Length];
            for (int i = 0; i < arrStr.Length; i++)
            {
                try
                {
                    arr[i] = Int32.Parse(arrStr[i]);
                }
                catch (FormatException)
                {
                    Console.WriteLine("Unable to parse " + arrStr[i]);
                }
            }

            try
            {
                this.target = Int32.Parse(lines[1]);
            }
            catch (FormatException)
            {
                Console.WriteLine("Unable to parse " + lines[1]);
            }
        }
    }


    // private int Max(int[] arr)
    // {
    //     int max = int.MinValue;
    //     foreach (int elem in arr)
    //     {
    //         if (elem > max)
    //             max = elem;
    //     }
    //     return max;
    // }

    // private int Sum(int[] arr)
    // {
    //     int sum = 0;
    //     foreach (int elem in arr)
    //         sum += elem;
    //     return sum;
    // }

    // private void ReduceArray(int[] arr, int value)
    // {
    //     for (int i = 0; i < arr.Length; i++)
    //     {
    //         if (arr[i] > value)
    //             arr[i] = value;
    //     }
    // }

    // public int GetRestrictedValue(int[] arr, int index, int restrictValue)
    // {
    //     return (arr[index] < restrictValue) ? arr[index] : restrictValue;
    // }

    public int GetRestrictedSum(int[] arr, int restrictValue)
    {
        int sum = 0;
        foreach (int val in arr)
            sum += (val < restrictValue) ? val : restrictValue;
        return sum;
    }

    private class Differ
    {
        private int[,] diffs;

        public Differ()
        {
            diffs = new int[2, 2];
            diffs[0, 0] = int.MaxValue;
            diffs[0, 1] = int.MaxValue;
            diffs[1, 0] = int.MaxValue;
            diffs[1, 1] = int.MaxValue;
        }

        public int GetAbsoluteDifferenceBetweenValues()
        {
            return (diffs[0, 0] == int.MaxValue || diffs[1, 0] == int.MaxValue) ? int.MaxValue : Math.Abs(diffs[0, 0] - diffs[1, 0]);
        }

        public int GetNumberOfAddedValues()
        {
            int count = (diffs[0, 0] < int.MaxValue) ? 1 : 0;
            count += (diffs[1, 0] < int.MaxValue) ? 1 : 0;
            return count;
        }

        public void SetValueAndDiff(int value, int diff)
        {
            if (Math.Abs(diff) > Math.Abs(diffs[0, 1]) && Math.Abs(diff) > Math.Abs(diffs[1, 1]))
                return;

            if (Math.Abs(diffs[0, 1]) > Math.Abs(diffs[1, 1]))
            {
                diffs[0, 0] = value;
                diffs[0, 1] = diff;
            }
            else
            {
                diffs[1, 0] = value;
                diffs[1, 1] = diff;
            }
        }

        public int GetClosestValue()
        {
            return Math.Abs(diffs[0, 1]) < Math.Abs(diffs[1, 1]) ? diffs[0, 0] : diffs[1, 0];
        }

        public int GetAbsoluteDifferenceOfClosestValue()
        {
            return Math.Abs(diffs[0, 1]) < Math.Abs(diffs[1, 1]) ? Math.Abs(diffs[0, 1]) : Math.Abs(diffs[1, 1]);
        }

        public int GetAverageValue()
        {
            if (diffs[0, 0] == int.MaxValue || diffs[1, 0] == int.MaxValue)
                return int.MaxValue / 2;
            return (diffs[0, 0] + diffs[1, 0]) / 2;
        }

        public int GetBestValue()
        {
            if (diffs[0, 1] < diffs[1, 1])
                return diffs[0, 0];
            else if (diffs[0, 1] > diffs[1, 1])
                return diffs[1, 0];
            else
                return (diffs[0, 0] < diffs[1, 0]) ? diffs[0, 0] : diffs[1, 0];
        }
    }

    // public int FindBestValue(int[] arr, int target)
    // {
    //     Differ differ = new Differ();
    //     int value = Max(arr);
    //     int sum = Sum(arr);
    //     differ.SetValueAndDiff(value, Math.Abs(sum - target));
    //     while (sum > target)
    //     {
    //         value--;
    //         ReduceArray(arr, value);
    //         sum = Sum(arr);
    //         differ.SetValueAndDiff(value, Math.Abs(sum - target));
    //     }
    //     return differ.GetBestValue();
    // }

    public int FindBestValue2(int[] arr, int target)
    {
        int value = int.MaxValue;
        Differ differ = new Differ();
        while (differ.GetAbsoluteDifferenceBetweenValues() > 1)
        {
            if (differ.GetNumberOfAddedValues() == 0)
                value = target / arr.Length;
            else if (differ.GetNumberOfAddedValues() == 1)
                value = (differ.GetClosestValue() + target) / 2;
            else
                value = differ.GetAverageValue();

            int diff = target - GetRestrictedSum(arr, value);
            differ.SetValueAndDiff(value, diff);
        }

        return differ.GetClosestValue();
    }
}