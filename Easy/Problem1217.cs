public class Problem1217
{
    public Problem1217()
    {
        Console.WriteLine(MinCostToMoveChips(new int[] { 1, 2, 3 }) == 1);
        Console.WriteLine(MinCostToMoveChips(new int[] { 2, 2, 2, 3, 3 }) == 2);
        Console.WriteLine(MinCostToMoveChips(new int[] { 1, 1000000000 }) == 1);
    }

    public int MinCostToMoveChips(int[] position)
    {
        int oddNumCount = 0;
        int evenNumCount = 0;
        foreach (int p in position)
        {
            if (p % 2 == 0)
                evenNumCount++;
            else
                oddNumCount++;
        }
        return oddNumCount < evenNumCount ? oddNumCount : evenNumCount;
    }
}