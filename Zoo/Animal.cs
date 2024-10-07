namespace Zoo
{
    internal class Animal
    {
        public Animal(string species, string sound, Gender gender)
        {
            Species = species;
            Sound = sound;
            Gender = gender;
        }

        public string Species { get; private set; }
        public string Sound { get; private set; }
        public Gender Gender { get; private set; }
    }
}
