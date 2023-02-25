public class Problem104
{
    public Problem104()
    {
        int[] vals = new int[]{1, 2, 3, 4, 5, 6, 7, 8};
        Tree tree = new Tree();
        foreach(int val in vals)
            tree.Insert(val);
        Console.WriteLine("Done.");
    }
}
