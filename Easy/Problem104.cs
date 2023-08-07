using System.Collections;

public class Problem104
{
    public Problem104()
    {
        int?[] vals = new int?[] { 3, 9, 20, null, null, 15, 7 };
        Tree tree = new Tree();
        tree.Insert(vals);
        Console.WriteLine(tree.MaxDepth() == 3);

        tree.Clear();

        vals = new int?[] { 1, null, 2 };
        tree.Insert(vals);
        Console.WriteLine(tree.MaxDepth() == 2);
    }
}
