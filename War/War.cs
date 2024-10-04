namespace War
{
    internal class War
    {
        private Platoon _platoonRed;
        private Platoon _platoonBlue;
        private SoldierFactory _soldiersFactory;

        public War()
        {
            _soldiersFactory = new SoldierFactory();
            _platoonRed = new Platoon("RED", _soldiersFactory.GenerateSoldiers());
            _platoonBlue = new Platoon("BLUE", _soldiersFactory.GenerateSoldiers());
        }

        public void Fight()
        {
            do
            {
                _platoonRed.Attack(_platoonBlue.Soldiers);
                _platoonBlue.Attack(_platoonRed.Soldiers);

                RemoveDeadSoldiers(_platoonRed, _platoonBlue);
                WriteFightInfo(_platoonRed, _platoonBlue);
            }
            while (_platoonRed.Count > 0 && _platoonBlue.Count > 0);

            ShowResult(_platoonRed, _platoonBlue);
        }

        private void WriteFightInfo(Platoon platoonOne, Platoon platoonTwo)
        {
            Console.WriteLine($"{platoonOne.Name} : {platoonOne.Count} - {platoonTwo.Name} : {platoonTwo.Count}");
        }

        private void ShowResult(Platoon platoonOne, Platoon platoonTwo)
        {
            if(_platoonRed.Count == 0 && _platoonBlue.Count == 0)
                Console.WriteLine("There were no winners in this battle");
            else if (_platoonRed.Count == 0)
                Console.WriteLine($"{_platoonRed.Name} is Dead! {_platoonBlue.Name} WIN");
            else if (_platoonBlue.Count == 0)
                Console.WriteLine($"{_platoonBlue.Name} is Dead! {_platoonRed.Name} WIN");
        }

        private void RemoveDeadSoldiers(Platoon platoonOne, Platoon platoonTwo)
        {
            _platoonRed.RemoveDeadSoldiers();
            _platoonBlue.RemoveDeadSoldiers();
        }
    }
}
