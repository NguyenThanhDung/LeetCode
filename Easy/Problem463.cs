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
        int perimeter = 0;

        for (int i = 0; i < grid.Length; i++)
        {
            for (int j = 0; j < grid[i].Length; j++)
            {
                if (grid[i][j] == 1)
                {
                    perimeter += 4;
                    if (i > 0 && grid[i - 1][j] == 1)
                        perimeter -= 2;
                    if (j > 0 && grid[i][j - 1] == 1)
                        perimeter -= 2;
                }
            }
        }

        return perimeter;
    }
}