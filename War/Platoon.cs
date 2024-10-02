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
            foreach (var soldier in _soldiers)
            {
                switch (soldier)
                {
                    case SoldierTwo soldierTwo:
                        soldierTwo.Attack(enemyPlatoon.GetRandomSoldier());
                        break;

                    case SoldierThree soldierThree:
                        soldierThree.Attack(enemyPlatoon.GetUniqueRandomSoldiers(soldierThree.EnemiesCountByAttack));
                        break;

                    case SoldierFour soldierFour:
                        soldierFour.Attack(enemyPlatoon.GetRandomSoldiers(soldierFour.EnemiesCountByAttack));
                        break;
                }
            }
        }

        public SoldierOne GetRandomSoldier()
        {
            int randomIndex = RandomUtil.GenerateInt(0, _soldiers.Count);

            return _soldiers[randomIndex];
        }

        public List<SoldierOne> GetRandomSoldiers(int count)
        {
            List<SoldierOne> soldiers = new List<SoldierOne>();

            for (int i = 0; i < count; i++)
            {
                soldiers.Add(GetRandomSoldier());
            }

            return soldiers;
        }

        public List<SoldierOne> GetUniqueRandomSoldiers(int count)
        {
            List<SoldierOne> soldiers = new List<SoldierOne>();

            if(count >= _soldiers.Count)
            {
                soldiers = _soldiers;
            }
            else
            {
                while (soldiers.Count < count)
                {
                    int newIndex = RandomUtil.GenerateInt(0, _soldiers.Count);

                    if (soldiers.Contains(_soldiers[newIndex]) == false)
                        soldiers.Add(_soldiers[newIndex]);
                }
            }

            return soldiers;
        }

        public void RemoveDeadSoldiers()
        {
            _soldiers = _soldiers.Where(soldier => soldier.IsAlive).ToList();
        }

        private bool IsIndexCorrect(int index)
        {
            return index >= 0 && index < _soldiers.Count;
        }

        private List<SoldierOne> GenerateSoldier(int soldierOne, int soldierTwo, int soldierThree, int soldierFour)
        {
            var soldiers = new List<SoldierOne>();

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
