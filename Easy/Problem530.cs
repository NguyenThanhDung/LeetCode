// https://leetcode.com/problems/minimum-absolute-difference-in-bst/description/
using System.Numerics;

public class Problem530
{
    public Problem530()
    {
        Tree tree = new Tree(new int?[] { 4, 2, 6, 1, 3 });
        Console.WriteLine(getMinimumDifference(tree.Root) == 1);

        tree = new Tree(new int?[] { 1, 0, 48, null, null, 12, 49 });
        Console.WriteLine(getMinimumDifference(tree.Root) == 1);

        tree = new Tree(new int?[] { 236, 104, 701, null, 227, null, 911 });
        Console.WriteLine(getMinimumDifference(tree.Root) == 9);
    }

    public int getMinimumDifference(TreeNode root)
    {
        (int, TreeNode) info = GetMinimumDifferenceRecursively(root, Int32.MaxValue, null);
        return info.Item1;
    }

    private (int minDifference, TreeNode previousNode) GetMinimumDifferenceRecursively(TreeNode node, int minDifference, TreeNode previousNode)
    {
        if (node == null)
            return (minDifference, previousNode);

        (int, TreeNode) leftBranchInfo = GetMinimumDifferenceRecursively(node.left, minDifference, previousNode);
        if (leftBranchInfo.Item1 < minDifference)
            minDifference = leftBranchInfo.Item1;
        previousNode = leftBranchInfo.Item2;

        if (previousNode != null)
        {
            int currentDifference = node.val - previousNode.val;
            if (currentDifference < minDifference)
                minDifference = currentDifference;
        }
        previousNode = node;

        (int, TreeNode) rightBranchInfo = GetMinimumDifferenceRecursively(node.right, minDifference, previousNode);
        if (rightBranchInfo.Item1 < minDifference)
            minDifference = rightBranchInfo.Item1;
        previousNode = rightBranchInfo.Item2;

        return (minDifference, previousNode);
    }
}