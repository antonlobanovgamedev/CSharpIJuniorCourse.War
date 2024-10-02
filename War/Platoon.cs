namespace War
{
    internal class Platoon
    {
        private List<SoldierOne> _soldiers;

        public Platoon(string name, int soldierOne, int soldierTwo, int soldierThree, int soldierFour)
        {
            _soldiers = GenerateSoldier(soldierOne, soldierTwo, soldierThree, soldierFour);

            Name = name;
        }

        public string Name { get; }

        public int Count =>
            _soldiers.Count;

        public void Attack(Platoon enemyPlatoon)
        {
            foreach(SoldierOne soldier in _soldiers)
            {
                soldier.AttackPlatoon(enemyPlatoon);
            }

            enemyPlatoon.RemoveDeadSoldiers();
        }

        public void RemoveDeadSoldiers()
        {
            var deadSoldiers = 
                _soldiers.Where(soldier => soldier.IsAlive == false).Select(soldier => soldier);

            _soldiers = _soldiers.Except(deadSoldiers).ToList();
        }

        public SoldierOne GetSoldier(int index)
        {
            if (IsIndexCorrect(index))
                return _soldiers[index];
            else
                return null;
        }

        private bool IsIndexCorrect(int index)
        {
            return index >= 0 && index < _soldiers.Count;
        }

        private List<SoldierOne> GenerateSoldier(int soldierOne, int soldierTwo, int soldierThree, int soldierFour)
        {
            var soldiers = new List<SoldierOne>();

            for (int i = 0; i < soldierOne; i++)
                _soldiers.Add(new SoldierOne());

            for (int i = 0; i < soldierTwo; i++)
                _soldiers.Add(new SoldierTwo());

            for (int i = 0; i < soldierThree; i++)
                _soldiers.Add(new SoldierThree());

            for (int i = 0; i < soldierFour; i++)
                _soldiers.Add(new SoldierFour());

            return soldiers;
        }
    }
}
