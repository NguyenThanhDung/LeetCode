public class Problem463
{
    public Problem463()
    {
        int[][] grid = new int[4][]
            {
                new int[] { 0, 1, 0, 0 },
                new int[] { 1, 1, 1, 0 },
                new int[] { 0, 1, 0, 0 },
                new int[] { 1, 1, 0, 0 }
            };
        Console.WriteLine(IslandPerimeter(grid) == 16);

        grid = new int[1][] { new int[] { 1 } };
        Console.WriteLine(IslandPerimeter(grid) == 4);

        grid = new int[1][] { new int[] { 1, 0 } };
        Console.WriteLine(IslandPerimeter(grid) == 4);
    }

    public int IslandPerimeter(int[][] grid)
    {
        return 0;
    }
}