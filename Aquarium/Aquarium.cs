namespace Aquarium
{
    internal class Aquarium
    {
        private List<Fish> _fishes;
        private int _maxFishesCount;

        public Aquarium()
        {
            _fishes = GenerateFishes();
            _maxFishesCount = 12;
        }

        public int Count => _fishes.Count;

        public void ShowFishes()
        {
            for (int i = 0; i < _fishes.Count; i++)
                Console.WriteLine($"FISH {i + 1}. IS ALIVE: {_fishes[i].IsAlive}. DAYS LEFT: {_fishes[i].DaysLeft}.");
        }

        public void SpendOneDay()
        {
            foreach (Fish fish in _fishes)
            {
                fish.LiveOneDay();
            }
        }

        public void RemoveFishAt(int index)
        {
            if (index >= 0 && index < _fishes.Count)
                _fishes.RemoveAt(index);
        }

        public void AddNewFish()
        {
            if(Count < _maxFishesCount)
                _fishes.Add(new Fish());
        }

        private List<Fish> GenerateFishes()
        {
            List<Fish> fish = new List<Fish>();
            int count = 3;

            for (int i = 0; i < count; i++)
                fish.Add(new Fish());

            return fish;
        }
    }
}
