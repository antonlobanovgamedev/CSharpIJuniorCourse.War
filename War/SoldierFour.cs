namespace War
{
    internal class SoldierFour : Soldier
    {
        public SoldierFour() : base()
        {
            EnemiesCountByAttack = 5;
        }

        public int EnemiesCountByAttack;

        public void Attack(List<Soldier> soldiers)
        {
            foreach (Soldier soldier in soldiers)
                soldier.TakeDamage(Damage);
        }
    }
}
