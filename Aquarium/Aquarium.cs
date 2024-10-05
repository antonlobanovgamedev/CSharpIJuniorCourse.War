namespace Aquarium
{
    internal class Aquarium
    {
        private List<Fish> _fish;

        public Aquarium()
        {
            _fish = GenerateFish();
        }

        public int Count => _fish.Count;

        public void ShowFish()
        {
            for (int i = 0; i < _fish.Count; i++)
                Console.WriteLine($"FISH {i + 1}. IS ALIVE: {_fish[i].IsAlive}. DAYS LEFT: {_fish[i].DaysLeft}.");
        }

        public void SpendOneDay()
        {
            foreach (Fish fish in _fish)
            {
                fish.LiveOneDay();
            }
        }

        public void RemoveFishAt(int index)
        {
            if (index >= 0 && index < _fish.Count)
                _fish.RemoveAt(index);
        }

        public void AddNewFish() =>
            _fish.Add(new Fish());

        private List<Fish> GenerateFish()
        {
            List<Fish> fish = new List<Fish>();
            int count = 3;

            for (int i = 0; i < count; i++)
                fish.Add(new Fish());

            return fish;
        }
    }
}
