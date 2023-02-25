public class Problem1300
{
    public Problem1300()
    {
        Console.WriteLine(FindBestValue(new int[] { 4, 9, 3 }, 10) == 3);
        Console.WriteLine(FindBestValue(new int[] { 2, 3, 5 }, 10) == 5);
        Console.WriteLine(FindBestValue(new int[] { 60864, 25176, 27249, 21296, 20204 }, 56803) == 11361);
    }

    private int Max(int[] arr)
    {
        int max = int.MinValue;
        foreach (int elem in arr)
        {
            if (elem > max)
                max = elem;
        }
        return max;
    }

    private int Sum(int[] arr)
    {
        int sum = 0;
        foreach (int elem in arr)
            sum += elem;
        return sum;
    }

    private void ReduceArray(int[] arr, int value)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] > value)
                arr[i] = value;
        }
    }

    private class Diff
    {
        private int[,] diffs;

        public Diff()
        {
            diffs = new int[2, 2];
            diffs[0, 0] = int.MaxValue;
            diffs[0, 1] = int.MaxValue;
            diffs[1, 0] = int.MaxValue;
            diffs[1, 1] = int.MaxValue;
        }

        public void SetValueAndDiff(int value, int diff)
        {
            if (diffs[0, 1] > diffs[1, 1])
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

    public int FindBestValue(int[] arr, int target)
    {
        Diff diff = new Diff();
        int value = Max(arr);
        int sum = Sum(arr);
        diff.SetValueAndDiff(value, Math.Abs(sum - target));
        while (sum > target)
        {
            value--;
            ReduceArray(arr, value);
            sum = Sum(arr);
            diff.SetValueAndDiff(value, Math.Abs(sum - target));
        }
        return diff.GetBestValue();
    }
}