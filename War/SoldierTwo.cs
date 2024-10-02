namespace War
{
    internal class SoldierTwo : SoldierOne
    {
        private int _damageMultiplier;

        public SoldierTwo() : base()
        {
            _damageMultiplier = 2;
        }

        public override void Attack(SoldierOne enemy) =>
            enemy.TakeDamage(Damage * _damageMultiplier);
    }
}
