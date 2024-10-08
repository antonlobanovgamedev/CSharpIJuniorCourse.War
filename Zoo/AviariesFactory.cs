namespace Zoo
{
    internal class AviariesFactory
    {
        private AnimalsFactory _animalsFactory;

        public AviariesFactory()
        {
            _animalsFactory = new AnimalsFactory();
        }

        public List<Aviary> GenerateAviaries()
        {
            List<Aviary> aviaries = new List<Aviary>();

            aviaries.Add(GenerateAviary("Tigers", "Tiger", "ROAR", 1, 3));
            aviaries.Add(GenerateAviary("Bears", "Bears", "GROWL", 1, 1));
            aviaries.Add(GenerateAviary("Goats", "Goat", "BLEEH", 4, 4));
            aviaries.Add(GenerateAviary("Ducks", "Duck", "QUACK", 6, 10));

            return aviaries;
        }

        private Aviary GenerateAviary(string label, string species, string sound, int maleCount, int femaleCount)
        {
            List<Animal> animals = new List<Animal>(maleCount + femaleCount);

            animals.AddRange(_animalsFactory.GenerateAnimals(species, sound, Gender.Male, maleCount));
            animals.AddRange(_animalsFactory.GenerateAnimals(species, sound, Gender.Female, femaleCount));

            Aviary aviary = new Aviary(label, animals);

            return aviary;
        }
    }
}
