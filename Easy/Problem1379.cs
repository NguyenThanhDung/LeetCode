using System;
using System.Collections;

public class Problem1379
{
    public Problem1379()
    {
        int?[] vals = new int?[] { 7, 4, 3, null, null, 6, 19 };
        Tree originalTree = new Tree();
        originalTree.Insert(vals);

        TreeNode node = originalTree.Find(3);

        vals = new int?[] { 7, 4, 3, null, null, 6, 19 };
        Tree clonedTree = new Tree();
        clonedTree.Insert(vals);

        TreeNode targetCopyNode = GetTargetCopy(originalTree.Root, clonedTree.Root, node);
        Console.WriteLine(targetCopyNode.val == node.val);
    }

    public TreeNode GetTargetCopy(TreeNode original, TreeNode cloned, TreeNode target)
    {
        if (original == null || cloned == null)
            return null;
        if (original == target)
            return cloned;

        TreeNode foundNode = GetTargetCopy(original.left, cloned.left, target);
        if (foundNode == null)
            foundNode = GetTargetCopy(original.right, cloned.right, target);

        return foundNode;
    }
}