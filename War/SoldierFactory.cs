namespace War
{
    class SoldierFactory
    {
        private Dictionary<Soldier, int> _soldiersMaxCountsBySoldierType;

        public SoldierFactory()
        {
            _soldiersMaxCountsBySoldierType = new()
            {
                { new SoldierOne(), 20},
                { new SoldierTwo(), 10},
                { new SoldierThree(), 10},
                { new SoldierFour(), 15}
            };
        }

        public List<Soldier> GenerateSoldiers()
        {
            var soldiers = new List<Soldier>();

            foreach(var soldiersMaxCountBySoldierType in _soldiersMaxCountsBySoldierType)
            {
                int soldierCount = RandomUtil.GenerateInt(0, soldiersMaxCountBySoldierType.Value);

                for(int i = 0; i < soldierCount; i++)
                {
                    soldiers.Add(soldiersMaxCountBySoldierType.Key.Clone());
                }
            }

            return soldiers;
        }
    }
}
