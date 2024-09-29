using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace War
{
    internal class Platoon
    {
        private List<Soldier> _soldiers;

        public Platoon(string name, int count)
        {
            _soldiers = CreateSoldiers(count);
            Name = name;
        }

        public string Name { get; }

        public int Count =>
            _soldiers.Count;

        public void Attack(Platoon enemyPlatoon)
        {
            foreach(Soldier soldier in _soldiers)
            {
                soldier.AttackPlatoon(enemyPlatoon);
            }

            enemyPlatoon.RemoveDeadSoldiers();
        }

        public void RemoveDeadSoldiers()
        {
            var deadSoldiers = 
                _soldiers.Where(soldier => soldier.IsAlive == false).Select(soldier => soldier);

            _soldiers = _soldiers.Except(deadSoldiers).ToList();
        }

        public Soldier GetSoldier(int index)
        {
            if (IsIndexCorrect(index))
                return _soldiers[index];
            else
                return null;
        }

        private List<Soldier> CreateSoldiers(int count)
        {
            List<Soldier> soldiers = new();

            for(int i = 0; i < count; i++)
            {
                soldiers.Add(new Soldier());
            }

            return soldiers;
        }

        private bool IsIndexCorrect(int index)
        {
            return index >= 0 && index < _soldiers.Count;
        }
    }
}
