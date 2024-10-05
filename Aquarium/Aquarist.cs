namespace Aquarium
{
    internal class Aquarist
    {
        private Aquarium _aquarium;

        public Aquarist()
        {
            _aquarium = new Aquarium();
        }

        public void Work()
        {
            const int SpendOneDayCommand = 1;
            const int AddNewFishCommand = 2;
            const int RemoveFishCommand = 3;
            const int ExitCommand = 4;

            bool isWorking = true;

            while (isWorking)
            {
                ShowAquarium(10);

                Console.WriteLine($"{SpendOneDayCommand}. Spend a day\n{AddNewFishCommand}. Add new fish\n" +
                    $"{RemoveFishCommand}. Remove a fish\n{ExitCommand}. Exit");
                Console.Write("\n>");

                string userInput = Console.ReadLine();

                if (int.TryParse(userInput, out int command))
                {
                    switch (command)
                    {
                        case 1:
                            _aquarium.SpendOneDay();
                            break;

                        case 2:
                            _aquarium.AddNewFish();
                            break;

                        case 3:
                            RemoveFish();
                            break;

                        case 4:
                            isWorking = false;
                            break;

                        default:
                            WriteError("!!! Unknown command !!!");
                            break;
                    }
                }
                else
                {
                    WriteError("!!!Incorrect input!!!");
                }

                Console.Clear();
            }
        }

        private void ShowAquarium(int topOffset)
        {
            var currectCursorPosition = Console.GetCursorPosition();
            Console.SetCursorPosition(0, topOffset);

            _aquarium.ShowFishes();

            Console.SetCursorPosition(currectCursorPosition.Left, currectCursorPosition.Top);
        }

        private void RemoveFish()
        {
            Console.Write("NUMBER: ");
            string userInput = Console.ReadLine();

            if (int.TryParse(userInput, out int number))
            {
                int index = number - 1;

                if (index >= 0 && index < _aquarium.Count)
                    _aquarium.RemoveFishAt(index);
                else
                    WriteError("!!! Incorect number !!!");
            }
            else
            {
                WriteError("!!! Incorrect Input !!!");
            }
        }

        private void WriteError(string errorDescription)
        {
            Console.WriteLine(errorDescription);
            Console.ReadKey();
        }
    }
}
