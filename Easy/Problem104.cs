using System.Collections;

public class Problem104
{
    public Problem104()
    {
        Queue<Object> vals = new Queue<Object>();
        vals.Enqueue(3);
        vals.Enqueue(9);
        vals.Enqueue(20);
        vals.Enqueue(null);
        vals.Enqueue(null);
        vals.Enqueue(15);
        vals.Enqueue(7);

        Tree tree = new Tree();
        tree.Insert(vals);
        Console.WriteLine(tree.MaxDepth() == 3);

        vals.Clear();
        tree.Clear();
        Console.WriteLine();
    }
}
