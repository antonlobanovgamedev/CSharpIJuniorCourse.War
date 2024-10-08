namespace Zoo
{
    internal class Zoo
    {
        private List<Aviary> _aviaries;
        private AviariesFactory _aviariesFactory;

        public Zoo()
        {
            _aviariesFactory = new AviariesFactory();
            _aviaries = _aviariesFactory.GenerateAviaries();   
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

        private void ShowAviariesLables()
        {
            for(int i = 0; i < _aviaries.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {_aviaries[i].Label}");
            }
        }
    }
}
