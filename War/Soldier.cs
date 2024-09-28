namespace War
{
    internal abstract class Soldier
    {
        public Soldier(int health, int damage, int armor)
        {
            Health = health;
            Damage = damage;
            Armor = armor;
        }

        public int Health { get; private set; }
        public int Damage { get; private set; }
        public int Armor { get; private set; }

        public void Attack(Platoon enemyPlatoon)
        {
            List<Soldier> enemies = GetEnemies(enemyPlatoon);

            foreach (Soldier enemy in enemies)
            {
                enemy.TakeDamage(Damage);
            }
        }

        public void TakeDamage(int damage)
        {
            int receivedDamage = CalculateReceivedDamage(damage);

            DecreaseHealth(receivedDamage);
        }

        protected virtual List<Soldier> GetEnemies(Platoon enemyPlatoon)
        {
            List<Soldier> enemies = new();

            int randomIndex = RandomUtil.GenerateInt(0, enemyPlatoon.Count);
            enemies.Add(enemyPlatoon.GetSoldier(randomIndex));

            return enemies;
        }

        protected void DecreaseHealth(int value)
        {
            if (value > 0)
                Health -= value;

            if (Health < 0)
                Health = 0;
        }

        protected int CalculateReceivedDamage(int damage)
        {
            if (damage > 0)
                damage -= Armor;

            if (damage < 0)
                damage = 0;

            return damage;
        }
    }
}
