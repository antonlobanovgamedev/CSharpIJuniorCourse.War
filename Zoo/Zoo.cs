namespace Zoo
{
    internal class Zoo
    {
        private List<Aviary> _aviaries;
        private AviaryFactory _aviaryFactory;

        public Zoo()
        {
            _aviaryFactory = new AviaryFactory();
            _aviaries = GenerateAviaries();   
        }

        public void Work()
        {
            const int ExitCommand = 0;

            bool isWorking = true;

            while (isWorking)
            {
                ShowAviariesLables();

                Console.WriteLine($"\nWrite number of the aviary ('{ExitCommand}' to exit):");
                Console.Write('>');

                string userInput = Console.ReadLine();

                if (int.TryParse(userInput, out int result))
                {
                    if (result == ExitCommand)
                    {
                        isWorking = false;
                    }
                    else if (result > 0 && result <= _aviaries.Count)
                    {
                        int index = result - 1;

                        _aviaries[index].ShowInfo();
                    }
                    else
                    {
                        Console.WriteLine("Incorrect number!");
                    }
                }
                else
                {
                    Console.WriteLine("Incorrect unput!");
                }

                Console.ReadKey();
                Console.Clear();
            }
        }

        private List<Aviary> GenerateAviaries()
        {
            List<Aviary> aviaries = new List<Aviary>();

            aviaries.Add(_aviaryFactory.GenerateAviary("Tigers", "Tiger", "ROAR", 1, 3));
            aviaries.Add(_aviaryFactory.GenerateAviary("Bears", "Bears", "GROWL", 1, 1));
            aviaries.Add(_aviaryFactory.GenerateAviary("Goats", "Goat", "BLEEH", 4, 4));
            aviaries.Add(_aviaryFactory.GenerateAviary("Ducks", "Duck", "QUACK", 6, 10));

            return aviaries;
        }

        private void ShowAviariesLables()
        {
            for(int i = 0; i < _aviaries.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {_aviaries[i].Label}");
            }
        }
    }
}
