public class Testing
{
    public static bool CompareArrays(int[] array1, int[] array2)
    {
        if (array1 == null || array2 == null)
            return false;

        if (array1.Length != array2.Length)
            return false;

        for (int i = 0; i < array1.Length; i++)
            if (array1[i] != array2[i])
                return false;

        return true;
    }

    public static bool CompareLists<T>(IList<T> list1, IList<T> list2)
    {
        if (list1 == null || list2 == null)
            return false;

        if (list1.Count != list2.Count)
            return false;

        for (int i = 0; i < list1.Count; i++)
            if (list1[i].Equals(list2[i]) == false)
                return false;

        return true;
    }
}
