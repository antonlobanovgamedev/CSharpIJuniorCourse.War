namespace War
{
    internal abstract class Soldier
    {
        protected int Damage;
        protected int Armor;
        protected int Health;

        public Soldier()
        {
            Health = 100;
            Damage = 15;
            Armor = 5;
        }

        public bool IsAlive =>
            Health > 0;

        public abstract void Attack(List<Soldier> soldiers);


        public void TakeDamage(int damage)
        {
            int receivedDamage = CalculateRecievedDamage(damage);

            DecreaseHealth(receivedDamage);
        }

        protected Soldier GetRandomEnemy(List<Soldier> enemies)
        {
            int randomIndex = RandomUtil.GenerateInt(0, enemies.Count);

            return enemies[randomIndex];
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
    }
}
