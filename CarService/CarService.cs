using System.Reflection.Metadata.Ecma335;

namespace CarService
{
    internal class CarService
    {
        private CarsFactory _carsFactory;
        private Queue<Car> _brokenCars;
        private Wallet _wallet;
        private Warehouse _warehouse;
        private Prices _prices;
        private int _initialCarsCountInQueue;

        public CarService()
        {
            _wallet = new Wallet();
            _warehouse = new Warehouse();
            _carsFactory = new CarsFactory();
            _prices = new Prices();
            _initialCarsCountInQueue = 10;
            _brokenCars = _carsFactory.GenerateCars(_initialCarsCountInQueue);
        }

        public void Work()
        {
            const int ShowWarehouseCommand = 1;
            const int ShowCarDetailsCommand = 2;
            const int RepairCarCommand = 3;
            const int RefuseToRepairCommand = 4;
            const int ExitCommand = 5;

            bool isWorking = true;

            while (isWorking && _brokenCars.Count > 0)
            {
                Car nextCar = _brokenCars.Peek();

                Colorizer.WriteWithColor("=== CAR SERVICE ===\n", ConsoleColor.Cyan);
                Colorizer.WriteWithColor($"Cars remain: {_brokenCars.Count}", ConsoleColor.Yellow);

                ShowBalance();

                Console.WriteLine($"{ShowWarehouseCommand}. Show the Warehouse\n" +
                    $"{ShowCarDetailsCommand}. Show current Car's details\n" +
                    $"{RepairCarCommand}. Start repairing the Car\n" +
                    $"{RefuseToRepairCommand}. Refuse to repair (-{_prices.GetPenalty(PenaltyType.RefuseBeforeRepair)}$)\n" +
                    $"{ExitCommand}. Exit\n");

                Console.Write(">");
                string? userInput = Console.ReadLine();

                if (int.TryParse(userInput, out int command))
                {
                    switch (command)
                    {
                        case ShowWarehouseCommand:
                            ShowWarehouse();
                            break;

                        case ShowCarDetailsCommand:
                            ShowCarDetails(nextCar);
                            break;

                        case RepairCarCommand:
                            RepairCar(_brokenCars.Dequeue());
                            break;

                        case RefuseToRepairCommand:
                            RefuseToRepair();
                            break;

                        case ExitCommand:
                            isWorking = false;
                            break;

                        default:
                            Colorizer.WriteWithColor("Incorrect Command!", ConsoleColor.Red);
                            break;
                    }
                }
                else
                {
                    Colorizer.WriteWithColor("Incorrect Input!", ConsoleColor.Red);
                }

                Console.ReadKey();
                Console.Clear();
            }
        }

        private (Detail warehouseDetail, Detail brokenCarDetail) GetDetailsForRepair(Car brokenCar)
        {
            Console.Write("Warehouse's detail: ");
            string? warehouseDetailsGroupNumberUserInput = Console.ReadLine();

            Console.Write("Car's detail: ");
            string? carDetailNumberUserInput = Console.ReadLine();

            bool isInputCorrect = int.TryParse(warehouseDetailsGroupNumberUserInput, out int warehouseDetailGroupNumber)
                & int.TryParse(carDetailNumberUserInput, out int carDetailNumber);

            if (isInputCorrect)
            {
                Detail warehouseDetail = _warehouse.Take(--warehouseDetailGroupNumber);
                Detail brokenCarDetail = brokenCar.GetDetail(--carDetailNumber);

                return (warehouseDetail, brokenCarDetail);
            }
            else
            {
                return (null, null);
            }
        }

        private bool IsRefusedToRepair()
        {
            const string ConfirmCommand = "y";
            const string RefuseCommand = "n";

            string? userInput = null;

            while (userInput != ConfirmCommand && userInput != RefuseCommand)
            {
                Console.Clear();
                Console.Write($"Continue? ({ConfirmCommand}/{RefuseCommand}): ");

                userInput = Console.ReadLine();
            }

            if (userInput == ConfirmCommand)
                return false;
            else
                return true;
        }

        private void RepairCar(Car car)
        {
            bool isRefusedToRepair = false;

            while (car.IsBroken && isRefusedToRepair == false)
            {
                Console.Clear();
                ShowCarDetails(car);
                Console.WriteLine();
                ShowWarehouse();
                Console.WriteLine();

                (Detail warehouseDetail, Detail brokenCarDetail) = GetDetailsForRepair(car);

                if(warehouseDetail == null || brokenCarDetail == null)
                {
                    Colorizer.WriteWithColor("Try again!", ConsoleColor.Yellow);
                }
                else
                {
                    if(warehouseDetail.Type != brokenCarDetail.Type)
                    {
                        Colorizer.WriteWithColor("Details' types are not the same!", ConsoleColor.Yellow);
                    }
                    else if(brokenCarDetail.IsBroken == false)
                    {
                        Colorizer.WriteWithColor("This detail was not broken!", ConsoleColor.Yellow);
                    }
                    else
                    {
                        if (IsRefusedToRepair())
                        {
                            isRefusedToRepair = true;

                            Colorizer.WriteWithColor($"You refused to repair! You must pay a penalty " +
                                $"{_prices.GetPenalty(PenaltyType.RefuseDuringRepairForOneDetail)} " +
                                $"for every unrepaired details!", ConsoleColor.Yellow);

                            int penaltyPrice = _prices.GetPenalty(PenaltyType.RefuseDuringRepairForOneDetail)
                                * car.GetBrokenDetailsCount();

                            _wallet.SpendMoney(penaltyPrice);

                            Colorizer.WriteWithColor($"Your paid {penaltyPrice}$.", ConsoleColor.Red);
                        }
                        else
                        {
                            car.SetNewDetail(brokenCarDetail, warehouseDetail);

                            int detailPrice = _prices.GetDetailPrice((DetailType)warehouseDetail.Type);
                            int priceForWork = _prices.GetReward(RewardType.PaymentForDetailReplacement);

                            int reward = detailPrice + priceForWork;

                            Colorizer.WriteWithColor($"You repaired this detail! You earned {reward}$!", ConsoleColor.Green);

                            _wallet.EarnMoney(reward);
                        }
                    }
                }

                Console.ReadKey();
            }
        }

        private void ShowBalance()
        {
            Colorizer.WriteWithColor("Balance: ", ConsoleColor.Yellow, false);

            if (_wallet.Balance < 0)
                Colorizer.WriteWithColor($"{_wallet.Balance}$", ConsoleColor.Red);
            else if (_wallet.Balance == 0)
                Colorizer.WriteWithColor($"{_wallet.Balance}$", ConsoleColor.White);
            else
                Colorizer.WriteWithColor($"{_wallet.Balance}$", ConsoleColor.Green);
        }

        private void RefuseToRepair()
        {
            int penaltyPrice = _prices.GetPenalty(PenaltyType.RefuseBeforeRepair);

            _brokenCars.Dequeue();
            _wallet.SpendMoney(penaltyPrice);

            Colorizer.WriteWithColor($"You refused to repair this car. \nYou paid the penalty : ${penaltyPrice}", ConsoleColor.Red);
        }

        private void ShowWarehouse()
        {
            Colorizer.WriteWithColor("[ WAREHOUSE ]", ConsoleColor.Yellow);

            _warehouse.ShowDetails();
        }

        private void ShowCarDetails(Car car)
        {
            Colorizer.WriteWithColor("[ CURRENT CAR's DETAILS ]", ConsoleColor.Yellow);

            car.ShowDetails();
        }
    }
}
