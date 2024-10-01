namespace War
{
    internal class SoldierOne
    {
        protected int Damage;
        protected int Armor;

        public SoldierOne()
        {
            Health = 100;
            Damage = 15;
            Armor = 5;
        }

        public int Health { get; private set; }

        public bool IsAlive =>
            Health > 0;

        public void TakeDamage(int damage)
        {
            int receivedDamage = CalculateRecievedDamage(damage);

            DecreaseHealth(receivedDamage);
        }

        public virtual void AttackPlatoon(Platoon enemyPlatoon)
        {
            List<SoldierOne> enemies = GetEnemies(enemyPlatoon);

            foreach (SoldierOne enemy in enemies)
                enemy.TakeDamage(Damage);
        }

        protected int CalculateRecievedDamage(int damage)
        {
            int receivedDamage = damage - Armor;

            if (receivedDamage < 0)
                receivedDamage = 0;

            return receivedDamage;
        }

        protected void DecreaseHealth(int value)
        {
            if (value <= 0)
                return;

            if (value > Health)
                Health = 0;
            else
                Health -= value;
        }

        protected List<SoldierOne> GetEnemies(Platoon enemiesPlatoon)
        {
            List<SoldierOne> enemies = new();
            List<int> enemiesIndexes = GetEnemiesIndexes(enemiesPlatoon);

            foreach (int index in enemiesIndexes)
            {
                enemies.Add(enemiesPlatoon.GetSoldier(index));
            }

            return enemies;
        }

        protected virtual List<int> GetEnemiesIndexes(Platoon enemiesPlatoon)
        {
            List<int> enemiesIndexes = new List<int>() { RandomUtil.GenerateInt(0, enemiesPlatoon.Count) };

            return enemiesIndexes;
        }
    }
}
