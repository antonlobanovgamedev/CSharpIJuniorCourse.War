namespace Aquarium
{
    internal class Fish
    {
        public Fish()
        {
            DaysLeft = 7;
        }

        public int DaysLeft { get; private set; }

        public bool IsAlive => DaysLeft > 0;

        public void LiveOneDay()
        {
            if (IsAlive)
                DaysLeft--;
        }
    }
}
