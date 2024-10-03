namespace War
{
    internal class SoldierThree : Soldier
    {
        private int _enemiesCountByAttack;

        public SoldierThree() : base()
        {
            _enemiesCountByAttack = 4;
        }

        public override void Attack(List<Soldier> soldiers)
        {
            List<Soldier> enemies = GetUniqueRandomEnemies(soldiers, _enemiesCountByAttack);

            foreach (Soldier enemy in enemies)
                enemy.TakeDamage(Damage);
        }

        private List<Soldier> GetUniqueRandomEnemies(List<Soldier> enemies, int count)
        {
            List<Soldier> soldiers = new List<Soldier>();

            if (count >= enemies.Count)
            {
                soldiers = enemies;
            }
            else
            {
                while (soldiers.Count < count)
                {
                    int newIndex = RandomUtil.GenerateInt(0, enemies.Count);

                    if (soldiers.Contains(enemies[newIndex]) == false)
                        soldiers.Add(enemies[newIndex]);
                }
            }

            return soldiers;
        }
    }
}
