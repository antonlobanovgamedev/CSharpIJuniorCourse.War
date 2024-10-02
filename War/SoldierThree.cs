namespace War
{
    internal class SoldierThree : SoldierOne
    {
        public SoldierThree() : base()
        {
            EnemiesCountByAttack = 4;
        }

        public int EnemiesCountByAttack;

        public void Attack(List<SoldierOne> soldiers)
        {
            foreach (SoldierOne soldier in soldiers)
                soldier.TakeDamage(Damage);
        }
    }
}
