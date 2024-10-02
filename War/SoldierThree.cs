namespace War
{
    internal class SoldierThree : Soldier
    {
        public SoldierThree() : base()
        {
            EnemiesCountByAttack = 4;
        }

        public int EnemiesCountByAttack;

        public void Attack(List<Soldier> soldiers)
        {
            foreach (Soldier soldier in soldiers)
                soldier.TakeDamage(Damage);
        }
    }
}
