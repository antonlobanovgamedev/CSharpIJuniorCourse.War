namespace War
{
    internal class Platoon
    {
        private List<Soldier> _soldiers;

        public Platoon(string name, int soldierOneCount, int soldierTwoCount, int soldierThreeCount, int soldierFourCount)
        {
            _soldiers = GenerateSoldier(soldierOneCount, soldierTwoCount, soldierThreeCount, soldierFourCount);

            Name = name;
        }

        public string Name { get; }

        public int Count =>
            _soldiers.Count;

        public void Attack(List<Soldier> enemies)
        {
            foreach(Soldier soldier in _soldiers)
                soldier.Attack(enemies);
        }

        public List<Soldier> GetSoldiers()
        {
            return _soldiers;
        }

        public void RemoveDeadSoldiers()
        {
            _soldiers = _soldiers.Where(soldier => soldier.IsAlive).ToList();
        }

        private List<Soldier> GenerateSoldier(int soldierOne, int soldierTwo, int soldierThree, int soldierFour)
        {
            var soldiers = new List<Soldier>();

            for (int i = 0; i < soldierOne; i++)
                soldiers.Add(new SoldierOne());

            for (int i = 0; i < soldierTwo; i++)
                soldiers.Add(new SoldierTwo());

            for (int i = 0; i < soldierThree; i++)
                soldiers.Add(new SoldierThree());

            for (int i = 0; i < soldierFour; i++)
                soldiers.Add(new SoldierFour());

            return soldiers;
        }
    }
}
