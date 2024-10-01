namespace War
{
    internal class Platoon
    {
        private List<SoldierOne> _soldiers;

        public Platoon(string name)
        {
            _soldiers = GenerateSoldier();

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

        private List<SoldierOne> GenerateSoldier()
        {
            var soldiers = new List<SoldierOne>()
            {
                new SoldierOne(),
                new SoldierOne(),
                new SoldierOne(),
                new SoldierOne(),

                new SoldierTwo(),
                new SoldierTwo(),
                new SoldierTwo(),
                new SoldierTwo(),

                new SoldierThree(),
                new SoldierThree(),
                new SoldierThree(),

                new SoldierFour(),
                new SoldierFour(),
                new SoldierFour(),
            };

            return soldiers;
        }
    }
}
