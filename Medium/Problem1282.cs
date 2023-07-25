using System.Text;

public class Problem1282
{
    public Problem1282()
    {
        IList<IList<int>> result = GroupThePeople(new int[] { 3, 3, 3, 3, 3, 1, 3 });
        Console.WriteLine(FormatResult(result));
    }

    public IList<IList<int>> GroupThePeople(int[] groupSizes)
    {
        Dictionary<int, LinkedList<List<int>>> dict = new Dictionary<int, LinkedList<List<int>>>();
        for (int i = 0; i < groupSizes.Length; i++)
        {
            int size = groupSizes[i];
            if (!dict.ContainsKey(size))
            {
                InitializeGroup(dict, size);
            }
            AddIndexToGroup(dict, size, i);
        }

        IList<IList<int>> result = new List<IList<int>>();
        foreach (KeyValuePair<int, LinkedList<List<int>>> pair in dict)
        {
            foreach (List<int> group in pair.Value)
            {
                result.Add(group);
            }
        }

        return result;
    }

    private void InitializeGroup(Dictionary<int, LinkedList<List<int>>> dict, int size)
    {
        LinkedList<List<int>> groups = new LinkedList<List<int>>();
        List<int> group = new List<int>();
        groups.AddFirst(group);
        dict.Add(size, groups);
    }

    private void AddIndexToGroup(Dictionary<int, LinkedList<List<int>>> dict, int size, int index)
    {
        LinkedList<List<int>> groups = dict[size];
        if (groups.First == null)
            return;
        List<int> firstGroup = groups.First.Value;
        if (firstGroup.Count < size)
        {
            firstGroup.Add(index);
        }
        else
        {
            List<int> newGroup = new List<int>();
            newGroup.Add(index);
            groups.AddFirst(newGroup);
        }
    }

    private String FormatResult(IList<IList<int>> result)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("[");
        for (int i = 0; i < result.Count; i++)
        {
            sb.Append("[");
            for (int j = 0; j < result[i].Count; j++)
            {
                sb.Append(result[i][j]);
                if (j < result[i].Count - 1)
                    sb.Append(",");
            }
            sb.Append("]");
            if (i < result.Count - 1)
                sb.Append(",");
        }
        sb.Append("]");
        return sb.ToString();
    }
}


// groupSizes = [3,3,3,3,3,1,3]
//
// i   groupSizes[i]   groups
// 0   3               [[0,_,_]]                   -> No size-3 group existed, create a size-3 group, add i into that group
// 1   3               [[0,1,_]]                   -> Size-3 group existed, add i into that group
// 2   3               [[0,1,2]]                   -> Size-3 group existed, add i into that group
// 3   3               [[0,1,2], [3,_,_]]          -> All size-3 groups are full, create a size-3 group, add i into that group
// 4   3               [[0,1,2], [3,4,_]]          -> Size-3 group existed, add i into that group
// 5   1               [[0,1,2], [3,4,_], [5]]     -> No size-1 group existed, create a size-1 group, add i into that group
// 6   3               [[0,1,2], [3,4,6], [5]]     -> Size-3 group existed, add i into that group
//
//
// groupSizes = [2,1,3,3,3,2]
//
// i   groupSizes[i]   groups
// 0   2               [[0,_]]                       -> No size-2 group existed, create a size-2 group, add i into that group
// 1   1               [[0,_],[1]]                   -> No size-1 group existed, create a size-1 group, add i into that group
// 2   3               [[0,_],[1],[2,_,_]]           -> No size-3 group existed, create a size-3 group, add i into that group
// 3   3               [[0,_],[1],[2,3,_]]           -> Size-3 group existed, add i into that group
// 4   3               [[0,_],[1],[2,3,4]]           -> Size-3 group existed, add i into that group
// 5   2               [[0,5],[1],[2,3,4]]           -> Size-2 group existed, add i into that group
