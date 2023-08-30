public class Problem226
{
    public Problem226()
    {
        Tree tree = new Tree(new int?[] { 4, 2, 7, 1, 3, 6, 9 });
        TreeNode invertRoot = InvertTree(tree.Root);
        Console.WriteLine();

        tree = new Tree(new int?[] { 2, 1, 3 });
        invertRoot = InvertTree(tree.Root);
        Console.WriteLine();
    }

    public TreeNode InvertTree(TreeNode root)
    {
        if (root == null)
            return root;
        TreeNode temp = root.left;
        root.left = root.right;
        root.right = temp;
        InvertTree(root.left);
        InvertTree(root.right);
        return root;
    }
}
