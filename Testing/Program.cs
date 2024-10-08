namespace Testing
{
    public class Program
    {
        static void Main(string[] args)
        {
            float f = Sum(0.1f, 0.2f);
            float g = Sum(0.1f, 0.2f);
            Console.WriteLine(f == g);
        }

        static float Sum(float f1, float f2)
        {
            return f1 + f2;
        }
    }
}
