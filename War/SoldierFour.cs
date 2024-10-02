namespace War
{
    internal class SoldierFour : SoldierOne
    {
        public SoldierFour() : base()
        {
            EnemiesCountByAttack = 5;
        }

        public int EnemiesCountByAttack;

        public void Attack(List<SoldierOne> soldiers)
        {
            foreach (SoldierOne soldier in soldiers)
                soldier.TakeDamage(Damage);
        }
    }
}
