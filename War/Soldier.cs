namespace War
{
    internal abstract class Soldier
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

        public virtual void Attack(Soldier enemy) =>
            enemy.TakeDamage(Damage);
            

        public void TakeDamage(int damage)
        {
            int receivedDamage = CalculateRecievedDamage(damage);

            DecreaseHealth(receivedDamage);
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

    internal class SoldierOne : Soldier { }
}
