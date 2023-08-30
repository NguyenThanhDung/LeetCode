using System.Diagnostics;

public class Problem1345
{
    public Problem1345()
    {
        Console.WriteLine(MinJumps(new int[] { 100, -23, -23, 404, 100, 23, 23, 23, 3, 404 }) == 3);
        Console.WriteLine(MinJumps(new int[] { 7 }) == 0);
        Console.WriteLine(MinJumps(new int[] { 7, 6, 9, 6, 9, 6, 9, 7 }) == 1);

        ExecuteFromFile("data1.txt");
        ExecuteFromFile("data2.txt");
        ExecuteFromFile("data3.txt");
    }

    private void ExecuteFromFile(string fileName)
    {
        var filePath = Path.Join(Directory.GetCurrentDirectory(), "Hard", "Problem1345", fileName);
        var lines = File.ReadAllLines(filePath);
        var intArray = new int[lines.Length];
        int intValue = 0;
        for (int i = 0; i < intArray.Length; i++)
        {
            if (Int32.TryParse(lines[i], out intValue))
                intArray[i] = intValue;
        }
        var watch = new Stopwatch();
        watch.Start();
        var result = MinJumps(intArray);
        watch.Stop();
        Console.WriteLine("Result: {0}. Execution Time: {1}", result, watch.ElapsedMilliseconds);
    }

    public int MinJumps(int[] arr)
    {
        var jumpablePositions = GetJumpablePositions(arr);
        Queue<int> queue = new Queue<int>();
        bool[] isVisited = new bool[arr.Length];
        isVisited[0] = true;
        queue.Enqueue(0);
        int[] distances = new int[arr.Length];
        distances[0] = 0;
        while (queue.Count > 0)
        {
            int index = queue.Dequeue();
            if (index == arr.Length - 1)
                return distances[index];
            if (index > 0 && isVisited[index - 1] == false)
            {
                isVisited[index - 1] = true;
                queue.Enqueue(index - 1);
                distances[index - 1] = distances[index] + 1;
            }
            if (index < arr.Length - 1 && isVisited[index + 1] == false)
            {
                isVisited[index + 1] = true;
                queue.Enqueue(index + 1);
                distances[index + 1] = distances[index] + 1;
            }
            var jumpablePositionsOfValue = jumpablePositions[arr[index]];
            foreach (int pos in jumpablePositionsOfValue)
            {
                if (isVisited[pos] == false)
                {
                    isVisited[pos] = true;
                    queue.Enqueue(pos);
                    distances[pos] = distances[index] + 1;
                }
            }
        }
        return distances[arr.Length - 1];
    }

    public Dictionary<int, List<int>> GetJumpablePositions(int[] arr)
    {
        var jumpablePosstionsDict = new Dictionary<int, List<int>>();
        for (int i = 0; i < arr.Length; i++)
        {
            if (jumpablePosstionsDict.ContainsKey(arr[i]))
            {
                var jumpablePosstions = jumpablePosstionsDict[arr[i]];
                jumpablePosstions.Add(i);
            }
            else
            {
                jumpablePosstionsDict.Add(arr[i], (new int[] { i }).ToList());
            }
        }
        return jumpablePosstionsDict;
    }
}