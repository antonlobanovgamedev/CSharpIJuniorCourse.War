namespace War
{
    internal class Platoon
    {
        private List<Soldier> _soldiers;


        public Platoon(string name, List<Soldier> soldiers)
        {
            _soldiers = soldiers;
            Name = name;
        }

        public string Name { get; }

        public int Count =>
            _soldiers.Count;

        public void Attack(List<Soldier> enemies)
        {
            foreach(Soldier soldier in _soldiers)
                soldier.Attack(enemies);
        }

        public List<Soldier> GetSoldiers()
        {
            List<Soldier> copiedSoldiers = new List<Soldier>();

            foreach(Soldier soldier in _soldiers)
                copiedSoldiers.Add(soldier);

            return copiedSoldiers;
        }

        public void RemoveDeadSoldiers()
        {
            _soldiers = _soldiers.Where(soldier => soldier.IsAlive).ToList();
        }
    }
}
