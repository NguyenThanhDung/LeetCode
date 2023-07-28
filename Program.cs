public class Program
{
    public static void Main()
    {
        String className = "Problem2663";
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
