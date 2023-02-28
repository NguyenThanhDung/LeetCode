using System.Collections;

public class Problem1379
{
    public Problem1379()
    {
        Queue<Object> vals = new Queue<Object>();
        vals.Enqueue(7);
        vals.Enqueue(4);
        vals.Enqueue(3);
        vals.Enqueue(null);
        vals.Enqueue(null);
        vals.Enqueue(6);
        vals.Enqueue(19);

        Tree originalTree = new Tree();
        originalTree.Insert(vals);

        TreeNode node = originalTree.Find(3);

        Tree clonedTree = new Tree();
        clonedTree.Insert(vals);
    }

    public TreeNode GetTargetCopy(TreeNode original, TreeNode cloned, TreeNode target) {
        return null;
    }
}