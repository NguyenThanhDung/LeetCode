public class Problem226
{
    public Problem226()
    {
        Tree tree = new Tree(new int?[] { 4, 2, 7, 1, 3, 6, 9 });
        TreeNode invertRoot = InvertTree(tree.Root);
        Console.WriteLine();
    }

    public TreeNode InvertTree(TreeNode root)
    {
        TreeNode temp = root.left;
        root.left = root.right;
        root.right = temp;
        if (root.left != null)
            InvertTree(root.left);
        if (root.right != null)
            InvertTree(root.right);
        return root;
    }
}
