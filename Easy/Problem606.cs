public class Problem606
{
    public Problem606()
    {
        Object[] treeArray = new Object[]{1, 2, 3, 4};
        Queue<Object> treeQueue = new Queue<Object>(treeArray);
        Tree tree = new Tree();
        tree.Insert(treeQueue);
        Console.WriteLine(Tree2str(tree.Root));
        tree.Clear();

        treeArray = new Object[]{1, 2, 3, null, 4};
        treeQueue = new Queue<Object>(treeArray);
        tree.Insert(treeQueue);
        Console.WriteLine(Tree2str(tree.Root));
        tree.Clear();
    }

    public string Tree2str(TreeNode root)
    {
        if(root == null)
            return "";
        string output = root.val.ToString();
        
        if(root.left != null || (root.left == null && root.right != null))
            output += "(" + Tree2str(root.left) + ")";

        if(root.right != null)
            output += "(" + Tree2str(root.right) + ")";

        return output;
    }
}