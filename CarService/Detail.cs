namespace CarService
{
    internal class Detail
    {
        public readonly DetailType? Type;

        public Detail(DetailType type, bool isBroken = false)
        {
            Type = type;
            IsBroken = isBroken;
        }

        public bool IsBroken { get; private set; }

        public void Broke() =>
            IsBroken = true;
    }
}
