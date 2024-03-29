using System.IO;

public class Problem1300
{
    public Problem1300()
    {
        Console.WriteLine(FindBestValue(new int[] { 4, 9, 3 }, 10) == 3);
        Console.WriteLine(FindBestValue(new int[] { 2, 3, 5 }, 10) == 5);
        Console.WriteLine(FindBestValue(new int[] { 60864, 25176, 27249, 21296, 20204 }, 56803) == 11361);
        Console.WriteLine(FindBestValue(new int[] { 2, 3, 5 }, 11) == 5);
        Console.WriteLine(FindBestValue(new int[] { 1, 2, 23, 24, 34, 36 }, 110) == 30);

        Input input = new Input("Medium/Problem1300", "input1.txt");
        Console.WriteLine(FindBestValue(input.arr, input.target) == 4);

        input = new Input("Medium/Problem1300", "input2.txt");
        Console.WriteLine(FindBestValue(input.arr, input.target) == 0);
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
            diffs[0, 0] = int.MinValue;
            diffs[0, 1] = int.MinValue;
            diffs[1, 0] = int.MaxValue;
            diffs[1, 1] = int.MaxValue;
        }

        public int GetAbsoluteDifferenceBetweenValues()
        {
            return (diffs[0, 0] == int.MaxValue || diffs[1, 0] == int.MaxValue) ? int.MaxValue : Math.Abs(diffs[0, 0] - diffs[1, 0]);
        }

        public int GetNumberOfAddedValues()
        {
            int count = (diffs[0, 0] > int.MinValue) ? 1 : 0;
            count += (diffs[1, 0] < int.MaxValue) ? 1 : 0;
            return count;
        }

        public void SetBottom(int value, int diff)
        {
            diffs[0, 0] = value;
            diffs[0, 1] = diff;
        }

        public void SetTop(int value, int diff)
        {
            diffs[1, 0] = value;
            diffs[1, 1] = diff;
        }

        public int GetClosestValue()
        {
            return Math.Abs(diffs[0, 1]) <= Math.Abs(diffs[1, 1]) ? diffs[0, 0] : diffs[1, 0];
        }

        public int GetAverageValue()
        {
            if (diffs[0, 0] == int.MaxValue || diffs[1, 0] == int.MaxValue)
                return int.MaxValue / 2;
            return (diffs[0, 0] + diffs[1, 0]) / 2;
        }
    }

    public int FindBestValue(int[] arr, int target)
    {
        int value = int.MaxValue;
        Differ differ = new Differ();
        while (differ.GetAbsoluteDifferenceBetweenValues() > 1)
        {
            if (differ.GetNumberOfAddedValues() == 0)
            {
                value = 0;
                int diff = GetRestrictedSum(arr, value) - target;
                differ.SetBottom(value, diff);
            }
            else if (differ.GetNumberOfAddedValues() == 1)
            {
                value = arr.Max();
                int diff = GetRestrictedSum(arr, value) - target;
                differ.SetTop(value, diff);
            }
            else
            {
                value = differ.GetAverageValue();
                int diff = GetRestrictedSum(arr, value) - target;
                if (diff < 0)
                    differ.SetBottom(value, diff);
                else
                    differ.SetTop(value, diff);
            }
        }

        return differ.GetClosestValue();
    }
}