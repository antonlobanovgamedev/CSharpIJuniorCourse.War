namespace Zoo
{
    internal class Aviary
    {
        private List<Animal> _animals;

        public Aviary(string label, List<Animal> animals)
        {
            _animals = animals;
            Label = label;
        }

        public string Label { get; private set; }

        public void ShowInfo()
        {
            Console.WriteLine($"= {Label} =");

            foreach(Animal animal in _animals)
            {
                Console.WriteLine($"\t{animal.Species}, Gender: {animal.Gender.ToString()}, Sound: {animal.Sound}");
            }
        }
    }
}
