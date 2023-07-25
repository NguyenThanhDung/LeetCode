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
        foreach(IList<int> list in result)
        {
            sb.Append("[");
            foreach(int num in list)
            {
                sb.Append(num + ",");
            }
            sb.Append("],");
        }
        sb.Append("]");
        return sb.ToString();
    }
}
