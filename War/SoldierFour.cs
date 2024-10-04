namespace War
{
    internal class SoldierFour : Soldier
    {
        private int _enemiesCountByAttack;

        public SoldierFour() : base()
        {
            _enemiesCountByAttack = 5;
        }

        public override SoldierFour Clone()
        {
            return new SoldierFour();
        }

        public override void Attack(List<Soldier> soldiers)
        {
            List<Soldier> enemies = GetRandomEnemies(soldiers, _enemiesCountByAttack);

            foreach (Soldier enemy in enemies)
                enemy.TakeDamage(Damage);
        }

        private List<Soldier> GetRandomEnemies(List<Soldier> enemies, int count)
        {
            List<Soldier> soldiers = new List<Soldier>();

            for (int i = 0; i < count; i++)
            {
                soldiers.Add(GetRandomEnemy(enemies));
            }

            return soldiers;
        }
    }
}
