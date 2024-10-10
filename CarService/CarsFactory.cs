namespace CarService
{
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
}
