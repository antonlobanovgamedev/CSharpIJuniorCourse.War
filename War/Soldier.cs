namespace War
{
    internal class Soldier
    {
        protected int Damage;
        protected int Armor;

        public Soldier()
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

        public void AttackPlatoon(Platoon enemyPlatoon)
        {
            List<Soldier> enemies = GetEnemies(enemyPlatoon);

            foreach (Soldier enemy in enemies)
                enemy.TakeDamage(Damage);

            enemyPlatoon.RemoveDeadSoldiers();
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

        protected List<Soldier> GetEnemies(Platoon enemiesPlatoon)
        {
            List<Soldier> enemies = new();
            int[] enemiesIndexes = GetEnemiesIndexes(enemiesPlatoon);

            foreach(int index in enemiesIndexes)
            {
                enemies.Add(enemiesPlatoon.GetSoldier(index));
            }
            
            return enemies;
        }

        protected virtual int[] GetEnemiesIndexes(Platoon enemiesPlatoon)
        {
            int[] enemiesIndexes = { RandomUtil.GenerateInt(0, enemiesPlatoon.Count) };
            
            return enemiesIndexes;
        }
    }
}
