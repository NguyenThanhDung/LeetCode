public class Problem1266
{
    public Problem1266()
    {
        Console.WriteLine(MinTimeToVisitAllPoints(new int[][] { new int[] { 1, 1 }, new int[] { 3, 4 }, new int[] { -1, 0 } }) == 7);
    }

    public int MinTimeToVisitAllPoints(int[][] points)
    {
        int minTime = 0;
        for (int i = 0; i < points.Length - 1; i++)
            minTime += MinTimeToVisitTwoPoints(points[i], points[i + 1]);
        return minTime;
    }

    public int MinTimeToVisitTwoPoints(int[] point1, int[] point2)
    {
        int h = Math.Abs(point2[0] - point1[0]);
        int v = Math.Abs(point2[1] - point1[1]);
        int minDiagon = Math.Min(h, v);

        // Find newA then calculate minStraight
        int minStraight = 0;
        return minDiagon + minStraight;
    }
}