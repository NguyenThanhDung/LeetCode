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
        return new int[][] { new int[] { 0, 0 }, new int[] { 0, 0 } };
    }
}