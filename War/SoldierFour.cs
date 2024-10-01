namespace War
{
    internal class SoldierFour : SoldierOne
    {
        private int _enemiesCountByAttack;

        public SoldierFour() : base()
        {
            _enemiesCountByAttack = 5;
        }

        protected override List<int> GetEnemiesIndexes(Platoon enemiesPlatoon)
        {
            List<int> enemiesIndexes = new();

            while (enemiesIndexes.Count < _enemiesCountByAttack)
            {
                int newIndex = RandomUtil.GenerateInt(0, enemiesPlatoon.Count);

                enemiesIndexes.Add(newIndex);
            }

            return enemiesIndexes;
        }
    }
}
