// https://leetcode.com/problems/minimum-absolute-difference-in-bst/description/
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

    const int MIN_VALUE = 0;
    const int MAX_VALUE = 100000;

    public int getMinimumDifference(TreeNode root)
    {
        (int, int, int) info = getMinimumDifferenceRecursively(root);
        return info.Item1;
    }

    private (int minDifference, int minValue, int maxValue) getMinimumDifferenceRecursively(TreeNode node)
    {
        if (node == null)
            return (MAX_VALUE, MAX_VALUE, MIN_VALUE);
        (int, int, int) leftInfo = getMinimumDifferenceRecursively(node.left);
        (int, int, int) rightInfo = getMinimumDifferenceRecursively(node.left);
        int minDifference = min(leftInfo.Item1, rightInfo.Item1, node.val - leftInfo.Item3, rightInfo.Item2 - node.val);
        return (minDifference, leftInfo.Item2, rightInfo.Item3);
    }

    private int min(int num1, int num2, int num3, int num4)
    {
        int min = num1;
        if (num2 < min)
            min = num2;
        if (num3 < min)
            min = num3;
        if (num4 < min)
            min = num4;
        return min;
    }
}