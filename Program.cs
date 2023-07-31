public class Program
{
    public static void Main()
    {
        int problemNumber = 66;
        String className = problemNumber < 1000 ? String.Format("Problem{0,3:D3}", problemNumber) : "Problem" + problemNumber;
        try
        {
            Type type = Type.GetType(className);
            Activator.CreateInstance(type);
        }
        catch (Exception e)
        {
            Console.WriteLine("Unable to load type {0}", className);
        }
    }
}
