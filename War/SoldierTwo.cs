namespace War
{
    internal class SoldierTwo : Soldier
    {
        private int _damageMultiplier;

        public SoldierTwo() : base()
        {
            _damageMultiplier = 2;
        }

        public override void Attack(Soldier enemy) =>
            enemy.TakeDamage(Damage * _damageMultiplier);
    }
}
