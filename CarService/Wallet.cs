namespace CarService
{
    internal class Wallet
    {
        public int Balance { get; private set; }

        public void EarnMoney(int value)
        {
            if(value > 0)
                Balance += value;
        }
            
        public void SpendMoney(int value)
        {
            if(value > 0)
                Balance -= value;
        }      
    }
}
