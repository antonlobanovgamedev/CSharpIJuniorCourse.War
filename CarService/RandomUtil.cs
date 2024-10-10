namespace CarService
{
    internal static class RandomUtil
    {
        private static Random s_random;

        static RandomUtil() =>
            s_random = new Random();

        public static int GenerateInt(int min, int max) =>
            s_random.Next(min, max);
    }
}
