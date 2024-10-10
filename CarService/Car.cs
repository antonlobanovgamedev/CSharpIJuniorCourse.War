namespace CarService
{
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

        public void SetNewDetail(Detail carDetail, Detail newDetail)
        {
            int carDetailIndex = _details.IndexOf(carDetail);

            _details[carDetailIndex] = newDetail;
        }

        public int GetBrokenDetailsCount()
        {
            int brokenDetailsCount = 0;

            foreach (Detail detail in _details) 
                if(detail.IsBroken)
                    brokenDetailsCount++;

            return brokenDetailsCount;
        }

        public Detail? GetDetail(int index)
        {
            if (index >= 0 && index < _details.Count)
                return _details[index];
            else
                return null;
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
}
