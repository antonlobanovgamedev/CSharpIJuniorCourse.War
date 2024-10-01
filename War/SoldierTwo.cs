namespace War
{
    internal class SoldierTwo : SoldierOne
    {
        private int _damageMultiplier;

        public SoldierTwo() : base()
        {
            _damageMultiplier = 2;
        }

        public override void AttackPlatoon(Platoon enemyPlatoon)
        {
            List<SoldierOne> enemies = GetEnemies(enemyPlatoon);

            foreach (SoldierOne enemy in enemies)
                enemy.TakeDamage(Damage * _damageMultiplier);
        }
    }
}
