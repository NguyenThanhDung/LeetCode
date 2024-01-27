// https://leetcode.com/problems/minimum-absolute-difference-in-bst/description/
public class Problem530
{
    public Problem530()
    {
        Tree tree = new Tree(new int?[] { 4, 2, 6, 1, 3 });
        Console.WriteLine(getMinimumDifference(tree.Root) == 1);

        tree = new Tree(new int?[] { 1, 0, 48, null, null, 12, 49 });
        Console.WriteLine(getMinimumDifference(tree.Root) == 1);
    }

    public int getMinimumDifference(TreeNode root)
    {
        return 0;
    }
}