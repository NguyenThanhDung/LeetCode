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
        return GetMinimumDifferenceRecursively(root, Int32.MaxValue, null);
    }

    private int GetMinimumDifferenceRecursively(TreeNode node, int minDifference, TreeNode previousNode)
    {
        if (node == null)
            return minDifference;

        int leftMinDifference = GetMinimumDifferenceRecursively(node.left, minDifference, previousNode);
        if (leftMinDifference < minDifference)
            minDifference = leftMinDifference;

        if (previousNode != null)
        {
            int currentDifference = node.val - previousNode.val;
            if (currentDifference < minDifference)
                minDifference = currentDifference;
        }
        previousNode = node;

        int rightMinDifference = GetMinimumDifferenceRecursively(node.right, minDifference, previousNode);
        if (rightMinDifference < minDifference)
            minDifference = rightMinDifference;

        return minDifference;
    }
}