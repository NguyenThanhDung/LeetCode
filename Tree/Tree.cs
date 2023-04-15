using System.Collections;

public class Tree
{
    private TreeNode root;

    public Tree()
    {
        root = null;
    }

    public TreeNode Root
    {
        get
        {
            return this.root;
        }
    }

    public void Insert(Queue<Object> values)
    {
        if (values == null || values.Count == 0)
            return;

        if (root == null)
        {
            Object value = values.Dequeue();
            if (value != null)
                root = new TreeNode((int)value);
            else
                return;
        }

        Queue<TreeNode> queue = new Queue<TreeNode>();
        queue.Enqueue(root);

        while (queue.Count > 0)
        {
            TreeNode node = queue.Dequeue();

            if (values.Count > 0 && node.left == null)
            {
                Object value = values.Dequeue();
                if (value != null)
                {
                    node.left = new TreeNode((int)value);
                    queue.Enqueue(node.left);
                }
            }

            if (values.Count > 0 && node.right == null)
            {
                Object value = values.Dequeue();
                if (value != null)
                {
                    node.right = new TreeNode((int)value);
                    queue.Enqueue(node.right);
                }
            }
        }
    }

    public int MaxDepth()
    {
        return GetDepthRecursively(this.root, 0);
    }

    private int GetDepthRecursively(TreeNode node, int currentDepth)
    {
        if (node == null)
            return currentDepth;
        int leftDepth = GetDepthRecursively(node.left, currentDepth + 1);
        int rightDepth = GetDepthRecursively(node.right, currentDepth + 1);
        return leftDepth > rightDepth ? leftDepth : rightDepth;
    }

    public void Clear()
    {
        ClearRecursively(this.root);
        this.root = null;
    }

    private void ClearRecursively(TreeNode node)
    {
        if (node == null)
            return;
        if (node.left != null && (node.left.left != null || node.left.right != null))
            ClearRecursively(node.left);
        if (node.right != null && (node.right.left != null || node.right.right != null))
            ClearRecursively(node.right);
        node.left = null;
        node.right = null;
    }

    public TreeNode Find(int value)
    {
        return FindRecursively(this.root, value);
    }

    private TreeNode FindRecursively(TreeNode node, int value)
    {
        if (node == null)
            return null;
        if (node.val == value)
            return node;

        TreeNode foundNode = FindRecursively(node.left, value);
        if (foundNode == null)
            foundNode = FindRecursively(node.right, value);

        return foundNode;
    }
}
