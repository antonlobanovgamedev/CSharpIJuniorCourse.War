namespace War
{
    internal class SoldierThree : SoldierOne
    {
        private int _enemiesCountByAttack;

        public SoldierThree() : base()
        {
            _enemiesCountByAttack = 4;
        }

        protected override List<int> GetEnemiesIndexes(Platoon enemiesPlatoon)
        {
            List<int> enemiesIndexes = new();
            bool isEnemiesFilled = false;

            while(isEnemiesFilled == false)
            {
                if(_enemiesCountByAttack > enemiesPlatoon.Count)
                    _enemiesCountByAttack = enemiesPlatoon.Count;

                int newIndex = RandomUtil.GenerateInt(0, _enemiesCountByAttack);

                if(enemiesIndexes.Contains(newIndex) == false)
                    enemiesIndexes.Add(newIndex);

                isEnemiesFilled = enemiesIndexes.Count == _enemiesCountByAttack;
            }           

            return enemiesIndexes;
        }
    }
}
