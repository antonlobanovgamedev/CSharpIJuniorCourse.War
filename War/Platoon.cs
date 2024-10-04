namespace War
{
    internal class Platoon
    { 
        public Platoon(string name, List<Soldier> soldiers)
        {
            Soldiers = soldiers;
            Name = name;
        }

        public List<Soldier> Soldiers { get; private set; }
        public string Name { get; }

        public int Count =>
            Soldiers.Count;

        public void Attack(List<Soldier> enemies)
        {
            foreach(Soldier soldier in Soldiers)
                soldier.Attack(enemies);
        }

        public void RemoveDeadSoldiers()
        {
            Soldiers = Soldiers.Where(soldier => soldier.IsAlive).ToList();
        }
    }
}
