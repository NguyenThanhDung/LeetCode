using System.Collections;

public class Tree
{
    private TreeNode root;

    public Tree()
    {
        root = null;
    }

    public Tree(IList<int?> values)
    {
        Insert(values);
    }

    public TreeNode Root
    {
        get
        {
            return this.root;
        }
    }

    public void Insert(IList<int?> values)
    {
        if (values == null || values.Count == 0)
            return;

        int currentIndex = 0;
        if (root == null)
        {
            var value = values[currentIndex];
            if (value.HasValue)
                root = new TreeNode(value.Value);
            else
                return;
        }
        currentIndex++;

        Queue<TreeNode> queue = new Queue<TreeNode>();
        queue.Enqueue(root);

        while (queue.Count > 0)
        {
            TreeNode node = queue.Dequeue();

            if (currentIndex < values.Count && node.left == null)
            {
                var value = values[currentIndex];
                if (value.HasValue)
                {
                    node.left = new TreeNode(value.Value);
                    queue.Enqueue(node.left);
                }
            }
            currentIndex++;

            if (currentIndex < values.Count && node.right == null)
            {
                var value = values[currentIndex];
                if (value.HasValue)
                {
                    node.right = new TreeNode(value.Value);
                    queue.Enqueue(node.right);
                }
            }
            currentIndex++;
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
