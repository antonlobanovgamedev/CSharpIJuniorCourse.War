namespace War
{
    internal class SoldierTwo : Soldier
    {
        private int _damageMultiplier;

        public SoldierTwo() : base()
        {
            _damageMultiplier = 2;
        }

        public override void Attack(List<Soldier> soldiers)
        {
            Soldier enemy = GetRandomEnemy(soldiers);

            enemy.TakeDamage(Damage * _damageMultiplier);
        }
    }
}
