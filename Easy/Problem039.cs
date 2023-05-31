public class Problem039
{
    public Problem039()
    {
        IList<IList<int>> result = CombinationSum(new int[]{2, 3, 6, 7}, 7);
        result = CombinationSum(new int[]{2, 3, 5}, 8);
        result = CombinationSum(new int[]{2}, 1);
        result = CombinationSum(new int[]{2, 3}, 6);
        result = CombinationSum(new int[]{8, 7, 4, 3}, 11);
        Console.WriteLine();
    }

    public IList<IList<int>> CombinationSum(int[] candidates, int target) {
        Array.Sort(candidates);

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

// candidates  2, 3, 6, 7
// target      7
//
// result = [[2, 2, 3], [7]]
//
// indexes         combination     sum     process
// [0]             [2]             2       < target => clone prev index
// [0, 0]          [2, 2]          4       < target => clone prev index
// [0, 0, 0]       [2, 2, 2]       6       < target => clone prev index
// [0, 0, 0, 0]    [2, 2, 2, 2]    8       > target => pop & increase value of the prev index
// [0, 0, 0]       [2, 2, 2]       
// [0, 0, 1]       [2, 2, 3]       7       == target => add to result & pop & increase value of the prev index
// [0, 0]          [2, 2]          
// [0, 1]          [2, 3]          5       < target => clone prev index
// [0, 1, 1]       [2, 3, 3]       8       > target => pop & increase value of the prev index
// [0, 1]          [2, 3]          
// [0, 2]          [2, 6]          8       > target => pop & increase value of the prev index
// [0]             [2]             
// [1]             [3]             3       < target => clone prev index
// [1, 1]          [3, 3]          6       < target => clone prev index
// [1, 1, 1]       [3, 3, 3]       9       > target => pop & increase value of the prev index
// [1, 1]          [3, 3]
// [1, 2]          [3, 6]          9       > target => pop & increase value of the prev index
// [1]             [3]
// [2]             [6]             6       < target => clone prev index
// [2, 2]          [6, 6]          12      > target => pop & increase value of the prev index
// [2]             [6]
// [3]             [7]             7       == target => add to result & pop & increase value of the prev index
// []              []                      empty -> return result