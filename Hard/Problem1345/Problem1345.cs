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
        List<int>[] jumpableSteps = GetJumpablePositions(arr);
        Stack<int> steps = new Stack<int>();
        return JumpRecursively(arr, 0, steps, jumpableSteps, arr.Length) - 1;
    }

    private int JumpRecursively(int[] arr, int index, Stack<int> steps, List<int>[] jumpableSteps, int minStepCount)
    {
        steps.Push(index);

        if (steps.Count > minStepCount)
        {
            steps.Pop();
            return minStepCount;
        }

        if (index == arr.Length - 1)
        {
            steps.Pop();
            return steps.Count + 1;
        }

        int nextStep = index + 1;
        if (nextStep < arr.Length && steps.Contains(nextStep) == false)
            minStepCount = JumpRecursively(arr, nextStep, steps, jumpableSteps, minStepCount);

        nextStep = index - 1;
        if (nextStep >= 0 && steps.Contains(nextStep) == false)
            minStepCount = JumpRecursively(arr, nextStep, steps, jumpableSteps, minStepCount);

        List<int> jumpableStepsOfIndex = jumpableSteps[index];
        foreach (int step in jumpableStepsOfIndex)
        {
            if (steps.Contains(step) == false)
            {
                minStepCount = JumpRecursively(arr, step, steps, jumpableSteps, minStepCount);
            }
        }

        steps.Pop();
        return minStepCount;
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