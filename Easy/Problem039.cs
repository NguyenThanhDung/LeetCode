public class Problem039
{
    public Problem039()
    {
        IList<IList<int>> result = CombinationSum(new int[]{2, 3, 6, 7}, 7);
        result = CombinationSum(new int[]{2, 3, 5}, 8);
        result = CombinationSum(new int[]{2}, 1);
        result = CombinationSum(new int[]{2, 3}, 6);
        Console.WriteLine();
    }

    public IList<IList<int>> CombinationSum(int[] candidates, int target) {
        List<IList<int>> result = new List<IList<int>>();
        List<int> indexes = new List<int>();
        List<int> combination = new List<int>();

        int sum = -1;
        do
        {
            int index = -1;
            while (sum < target)
            {
                index = indexes.Count == 0 ? 0 : indexes.Last();
                indexes.Add(index);
                combination.Add(candidates[index]);
                sum = combination.Sum();
            }
            if (sum == target)
            {
                result.Add(combination.ToList());
            }

            indexes.RemoveAt(indexes.Count - 1);
            combination.RemoveAt(combination.Count - 1);

            if(indexes.Count > 0)
            {
                index = indexes.Last() + 1;
                if (index >= candidates.Length)
                {
                    sum = target + 1;
                    continue;
                }
                indexes[indexes.Count - 1] = index;
                combination[combination.Count - 1] = candidates[index];
                sum = combination.Sum();
            }
        }
        while(indexes.Count > 0);

        return result;
    }
}