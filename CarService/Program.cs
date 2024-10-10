using System.Dynamic;

namespace CarService
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CarService carService = new CarService();
            carService.Work();
        }
    }

    internal static class RandomUtil
    {
        private static Random s_random;

        static RandomUtil() =>
            s_random = new Random();

        public static int GenerateInt(int min, int max) =>
            s_random.Next(min, max);
    }

    internal static class Colorizer
    {
        public static void WriteWithColor(string text, ConsoleColor color)
        {
            ConsoleColor currentColor = Console.ForegroundColor;
            Console.ForegroundColor = color;

            Console.WriteLine(text);

            Console.ForegroundColor = currentColor;
        }
    }

    internal class BusinessConditions
    {
        private Dictionary<DetailType, int> _priceByDetailType;
        private Dictionary<PenaltyType, int> _penaltyByPenaltyType;
        private Dictionary<RewardType, int> _rewardByRewardType;

        public BusinessConditions()
        {
            _priceByDetailType = new Dictionary<DetailType, int>()
            {
                { DetailType.Engine, 3000},
                { DetailType.TailPipe, 100},
                { DetailType.Wheel, 200},
                { DetailType.Glass, 200},
                { DetailType.Bumper, 150},
                { DetailType.FrontDoor, 300},
                { DetailType.BackDoor, 300},
                { DetailType.Headlight, 50},
                { DetailType.Backlight, 100},
                { DetailType.Battery, 150},
                { DetailType.Carburetor, 1000},
            };

            _penaltyByPenaltyType = new Dictionary<PenaltyType, int>()
            {
                { PenaltyType.RefuseBeforeRepair, 250},
                { PenaltyType.RefuseDuringRepairForOneDetail, 200},
            };

            _rewardByRewardType = new Dictionary<RewardType, int>()
            {
                { RewardType.PaymentForDetailReplacement, 500 }
            };
        }

        public int GetDetailPrice(DetailType type) =>
            _priceByDetailType[type];

        public int GetPenalty(PenaltyType type) =>
            _penaltyByPenaltyType[type];

        public int GetReward(RewardType type) =>
            _rewardByRewardType[type];
    }

    internal class Warehouse
    {
        private DetailsFactory _detailsFactory;
        private List<Detail> _details;
        private int _initialDetailsCount;

        public Warehouse()
        {
            _detailsFactory = new DetailsFactory();
            _initialDetailsCount = 30;
            _details = _detailsFactory.GenerateRandomDetails(_initialDetailsCount);
        }

        public int DetailsCount =>
            _details.Count;

        public void ShowDetails()
        {
            for (int i = 0; i < _details.Count; i++)
                Console.WriteLine($"{i + 1}. {_details[i].Type}");
        }

        public Detail? UseDetail(int index)
        {
            if (index >= 0 && index < _details.Count)
            {
                Detail detail = _details[index];

                _details.RemoveAt(index);

                return detail;
            }
            else
            {
                return null;
            }
        }
    }

    internal class Wallet
    {
        public int Balance { get; private set; }

        public void EarnMoney(int value) =>
            Balance = value;

        public void SpendMoney(int value) =>
            Balance -= value;
    }

    internal class CarService
    {
        private CarsFactory _carsFactory;
        private Queue<Car> _brokenCars;
        private Wallet _wallet;
        private Warehouse _warehouse;
        private BusinessConditions _businessConditions;
        private int _initialCarsCountInQueue;

        public CarService()
        {
            _wallet = new Wallet();
            _warehouse = new Warehouse();
            _carsFactory = new CarsFactory();
            _businessConditions = new BusinessConditions();
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

            while (isWorking)
            {
                Colorizer.WriteWithColor("=== CAR SERVICE ===\n", ConsoleColor.Cyan);
                Colorizer.WriteWithColor("Cars remain: " + _brokenCars.Count, ConsoleColor.Yellow);
                Console.WriteLine($"{ShowWarehouseCommand}. Show the Warehouse\n" +
                    $"{ShowCarDetailsCommand}. Show current Car's details\n" +
                    $"{RepairCarCommand}. Start repairing the Car\n" +
                    $"{RefuseToRepairCommand}. Refuse to repair\n" +
                    $"{ExitCommand}. Exit\n");

                Console.ReadKey();
                Console.Clear();
            }
        }

        private void RefuseToRepair()
        {
            int penaltyPrice = _businessConditions.GetPenalty(PenaltyType.RefuseBeforeRepair);

            _wallet.SpendMoney(penaltyPrice);

            Colorizer.WriteWithColor($"You refused to repair this car. You paid the penalty : ${penaltyPrice}", ConsoleColor.Red);
        }

        private void ShowWarehouse()
        {
            Colorizer.WriteWithColor("\n[ WAREHOUSE ]", ConsoleColor.Yellow);

            if (_warehouse.DetailsCount > 0)
                _warehouse.ShowDetails();
            else
                Console.WriteLine("EMPTY");
        }

        private void ShowCarDetails(Car car)
        {
            Colorizer.WriteWithColor("\n[ CURRENT CAR's DETAILS ]", ConsoleColor.Yellow);

            car.ShowDetails();
        }
    }

    internal class CarsFactory
    {
        public Queue<Car> GenerateCars(int count)
        {
            Queue<Car> cars = new();

            for (int i = 0; i < count; i++)
                cars.Enqueue(new Car());

            return cars;
        }
    }

    internal class DetailsFactory
    {
        public List<Detail> GenerateCarDetails()
        {
            List<Detail> details = new();
            int detailsTypesCount = Enum.GetNames(typeof(DetailType)).Length;

            for (int i = 0; i < detailsTypesCount; i++)
                details.Add(new Detail((DetailType)i));

            return details;
        }

        public List<Detail> GenerateRandomDetails(int detailsCount)
        {
            List<Detail> details = new();
            int detailsTypesCount = Enum.GetNames(typeof(DetailType)).Length;

            for (int i = 0; i < detailsCount; i++)
            {
                int randomDetailTypeIndex = RandomUtil.GenerateInt(1, detailsTypesCount);

                details.Add(new Detail((DetailType)randomDetailTypeIndex));
            }

            return details;
        }
    }

    internal class Car
    {
        private List<Detail> _details;
        private DetailsFactory _detailsFactory;

        public Car()
        {
            _detailsFactory = new DetailsFactory();
            _details = _detailsFactory.GenerateCarDetails();
            Broke();
        }

        public bool IsBroken
        {
            get
            {
                bool isBroken = false;

                foreach (Detail detail in _details)
                {
                    if (detail.IsBroken)
                        isBroken = true;
                }

                return isBroken;
            }
        }

        public void ShowDetails()
        {
            for (int i = 0; i < _details.Count; i++)
            {
                if (_details[i].IsBroken)
                    Colorizer.WriteWithColor($"{i + 1}. {_details[i].Type}", ConsoleColor.Red);
                else
                    Console.WriteLine($"{i + 1}. {_details[i].Type}");
            }
        }

        private void Broke()
        {
            int minBrokenDetails = 1;
            int maxBrokenDetails = 5;

            if (IsBroken)
                return;

            if (maxBrokenDetails > _details.Count)
                maxBrokenDetails = _details.Count;

            int brokenDetailsCount = RandomUtil.GenerateInt(minBrokenDetails, maxBrokenDetails);

            for (int i = 0; i < brokenDetailsCount; i++)
            {
                bool isCurrentDetailBroken = false;

                while (isCurrentDetailBroken == false)
                {
                    int randomIndex = RandomUtil.GenerateInt(0, _details.Count);

                    if (_details[randomIndex].IsBroken == false)
                    {
                        _details[randomIndex].Broke();

                        isCurrentDetailBroken = true;
                    }
                }
            }
        }
    }

    internal class Detail
    {
        public readonly DetailType Type;

        public Detail(DetailType type, bool isBroken = false)
        {
            Type = type;
            IsBroken = isBroken;
        }

        public bool IsBroken { get; private set; }

        public void Broke() =>
            IsBroken = true;
    }

    internal enum DetailType
    {
        Engine,
        TailPipe,
        Wheel,
        Glass,
        Bumper,
        FrontDoor,
        BackDoor,
        Headlight,
        Backlight,
        Battery,
        Carburetor
    }

    internal enum PenaltyType
    {
        RefuseBeforeRepair,
        RefuseDuringRepairForOneDetail
    }

    internal enum RewardType
    {
        PaymentForDetailReplacement
    }
}
