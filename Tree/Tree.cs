public class Tree
{
    private TreeNode root;

    public Tree()
    {
        root = null;
    }

    public void Insert(int value)
    {
        if (root == null)
        {
            root = new TreeNode(value);
        }
        else
        {
            InsertRec(root, new TreeNode(value));
        }
    }

    public void InsertRec(TreeNode root, TreeNode newNode)
    {
        if (newNode.val < root.val)
        {
            if (root.left == null)
                root.left = newNode;
            else
                InsertRec(root.left, newNode);
        }
        else
        {
            if (root.right == null)
                root.right = newNode;
            else
                InsertRec(root.right, newNode);
        }
    }
}