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
        (int, int, int) info = GetMinimumDifferenceRecursively(root);
        return info.Item1;
    }

    private (int minDifference, int minValue, int maxValue) GetMinimumDifferenceRecursively(TreeNode node)
    {
        if (node == null)
            return (MAX_VALUE, MAX_VALUE, MIN_VALUE);
        (int, int, int) leftInfo = GetMinimumDifferenceRecursively(node.left);
        (int, int, int) rightInfo = GetMinimumDifferenceRecursively(node.left);
        int minDifference = Min(leftInfo.Item1, rightInfo.Item1, node.val - leftInfo.Item3, rightInfo.Item2 - node.val);
        return (minDifference, leftInfo.Item2, rightInfo.Item3);
    }

    private int Min(int leftMinDifference, int rightMinDifference, int leftMaxValue, int rightMinValue)
    {
        int min = leftMinDifference;
        if (rightMinDifference < min)
            min = rightMinDifference;
        if (leftMaxValue < min)
            min = leftMaxValue;
        if (rightMinValue < min)
            min = rightMinValue;
        return min;
    }
}