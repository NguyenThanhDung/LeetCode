public class Problem1345
{
    public Problem1345()
    {
        Console.WriteLine(MinJumps(new int[] { 100, -23, -23, 404, 100, 23, 23, 23, 3, 404 }) == 3);
        Console.WriteLine(MinJumps(new int[] { 7 }) == 0);
        Console.WriteLine(MinJumps(new int[] { 7, 6, 9, 6, 9, 6, 9, 7 }) == 1);
    }

    public int MinJumps(int[] arr)
    {
        List<int>[] jumpablePosstions = GetJumpablePositions(arr);
        return 0;
    }

    public List<int>[] GetJumpablePositions(int[] arr)
    {
        List<int>[] jumpablePosstions = new List<int>[arr.Length];
        for (int i = 0; i < arr.Length; i++)
        {
            jumpablePosstions[i] = new List<int>();
            for (int j = 0; j < arr.Length; j++)
            {
                if (i != j && arr[i] == arr[j])
                    jumpablePosstions[i].Add(j);
            }
        }
        return jumpablePosstions;
    }
}