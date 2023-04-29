public class Problem2373
{
    public Problem2373()
    {
        int[][] result = LargestLocal(new int[][] { new int[] { 9, 9, 8, 1 }, new int[] { 5, 6, 2, 6 }, new int[] { 8, 2, 6, 4 }, new int[] { 6, 2, 2, 2 } });
        Console.WriteLine(AreEqual(result, new int[][] { new int[] { 9, 9 }, new int[] { 8, 6 } }));

        result = LargestLocal(new int[][] { new int[] { 1, 1, 1, 1, 1 }, new int[] { 1, 1, 1, 1, 1 }, new int[] { 1, 1, 2, 1, 1 }, new int[] { 1, 1, 1, 1, 1 }, new int[] { 1, 1, 1, 1, 1 } });
        Console.WriteLine(AreEqual(result, new int[][] { new int[] { 2, 2, 2 }, new int[] { 2, 2, 2 }, new int[] { 2, 2, 2 } }));
    }

    private bool AreEqual(int[][] array1, int[][] array2)
    {
        bool areEqual = true;
        if (array1.Length == array2.Length)
        {
            for (int i = 0; i < array1.Length; i++)
            {
                if (!array1[i].SequenceEqual(array2[i]))
                {
                    areEqual = false;
                    break;
                }
            }
        }
        else
        {
            areEqual = false;
        }
        return areEqual;
    }

    public int[][] LargestLocal(int[][] grid)
    {
        int[][] largestLocal = new int[grid.Length - 2][];
        for (int i = 0; i < largestLocal.Length; i++)
        {
            largestLocal[i] = new int[grid[0].Length - 2];
            for (int j = 0; j < largestLocal[i].Length; j++)
            {
                largestLocal[i][j] = FindLargest(grid, i + 1, j + 1);
            }
        }
        return largestLocal;
    }

    private int FindLargest(int[][] grid, int i, int j)
    {
        int max = int.MinValue;
        for (int k = i - 1; k <= i + 1; k++)
        {
            for (int l = j - 1; l <= j + 1; l++)
            {
                if (grid[k][l] > max)
                    max = grid[k][l];
            }
        }
        return max;
    }
}