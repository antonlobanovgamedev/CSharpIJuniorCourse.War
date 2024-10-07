namespace Zoo
{
    internal class AviaryFactory
    {
        public Aviary GenerateAviary(string label, string species, string sound, int maleCount, int femaleCount)
        {
            List<Animal> animals = new List<Animal>(maleCount + femaleCount);

            animals.AddRange(GenerateAnimals(species, sound, Gender.Male, maleCount));
            animals.AddRange(GenerateAnimals(species, sound, Gender.Female, femaleCount));

            Aviary aviary = new Aviary(label, animals);

            return aviary;
        }

        private List<Animal> GenerateAnimals(string species, string sound, Gender gender, int count)
        {
            List<Animal> animals = new List<Animal>();

            for (int i = 0; i < count; i++)
                animals.Add(new Animal(species, sound, gender));

            return animals;
        }
    }
}
