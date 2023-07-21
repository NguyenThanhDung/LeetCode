public class Problem1345
{
    public Problem1345()
    {
        Console.WriteLine(MinJumps(new int[] { 100, -23, -23, 404, 100, 23, 23, 23, 3, 404 }) == 3);
        Console.WriteLine(MinJumps(new int[] { 7 }) == 0);
        Console.WriteLine(MinJumps(new int[] { 7, 6, 9, 6, 9, 6, 9, 7 }) == 1);
    }

    public int MinJumps(int[] arr)
    {
        List<int>[] jumpablePositions = GetJumpablePositions(arr);
        Queue<int> queue = new Queue<int>();
        bool[] isVisited = new bool[arr.Length];
        queue.Enqueue(0);
        int currentDistance = 0;
        int[] distances = new int[arr.Length];
        while (queue.Count > 0)
        {
            int index = queue.Dequeue();
            if (index == arr.Length - 1)
                return currentDistance;
            distances[index] = currentDistance;
            if (index > 0 && isVisited[index - 1] == false)
            {
                isVisited[index - 1] = true;
                queue.Enqueue(index - 1);
            }
            if (index < arr.Length - 1 && isVisited[index + 1] == false)
            {
                isVisited[index + 1] = true;
                queue.Enqueue(index + 1);
            }
            List<int> jumpablePositionsOfIndex = jumpablePositions[index];
            foreach (int pos in jumpablePositionsOfIndex)
            {
                if (isVisited[pos])
                {
                    isVisited[pos] = true;
                    queue.Enqueue(pos);
                }
            }
            currentDistance++;
        }
        return distances[arr.Length - 1];
    }

    public List<int>[] GetJumpablePositions(int[] arr)
    {
        List<int>[] jumpablePosstions = new List<int>[arr.Length];
        for (int i = 0; i < arr.Length; i++)
        {
            jumpablePosstions[i] = new List<int>();
            for (int j = 0; j < arr.Length; j++)
            {
                if (i != j && arr[i] == arr[j])
                    jumpablePosstions[i].Add(j);
            }
        }
        return jumpablePosstions;
    }
}