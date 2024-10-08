namespace Zoo
{
    internal class AnimalsFactory
    {
        public List<Animal> GenerateAnimals(string species, string sound, Gender gender, int count)
        {
            List<Animal> animals = new List<Animal>();

            for (int i = 0; i < count; i++)
                animals.Add(new Animal(species, sound, gender));

            return animals;
        }
    }
}
