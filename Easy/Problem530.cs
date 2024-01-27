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
        if (root == null)
            return 100000;
        int minDifference = 100000;
        if (root.left != null)
        {
            minDifference = getMinimumDifference(root.left);
            int leftDifference = root.val - root.left.val;
            minDifference = leftDifference < minDifference ? leftDifference : minDifference;
        }
        if (root.right != null)
        {
            int rightDifference = getMinimumDifference(root.right);
            minDifference = rightDifference < minDifference ? rightDifference : minDifference;

            rightDifference = root.right.val - root.val;
            minDifference = rightDifference < minDifference ? rightDifference : minDifference;
        }
        return minDifference;
    }
}