public class Problem606
{
    public Problem606()
    {
        Object[] treeArray = new Object[]{1, 2, 3, 4};
        Queue<Object> treeQueue = new Queue<Object>(treeArray);
        Tree tree = new Tree();
        tree.Insert(treeQueue);
        tree.Clear();

        treeArray = new Object[]{1, 2, 3, null, 4};
        treeQueue = new Queue<Object>(treeArray);
        tree.Insert(treeQueue);
        tree.Clear();
    }

    public string Tree2str(TreeNode root)
    {
        return null;
    }
}