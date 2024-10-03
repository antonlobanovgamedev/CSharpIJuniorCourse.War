namespace War
{
    internal class War
    {
        private Platoon platoonRed;
        private Platoon platoonBlue;

        public War()
        {
            platoonRed = new Platoon("RED", 4, 2, 5, 4);
            platoonBlue = new Platoon("BLUE", 5, 4, 2, 5);
        }

        public void Fight()
        {
            do
            {
                platoonRed.Attack(platoonBlue.GetSoldiers());
                platoonBlue.Attack(platoonRed.GetSoldiers());

                RemoveDeadSoldiers(platoonRed, platoonBlue);
                WriteFightInfo(platoonRed, platoonBlue);
            }
            while (platoonRed.Count > 0 && platoonBlue.Count > 0);

            ShowResult(platoonRed, platoonBlue);
        }

        private void WriteFightInfo(Platoon platoonOne, Platoon platoonTwo)
        {
            Console.WriteLine($"{platoonOne.Name} : {platoonOne.Count} - {platoonTwo.Name} : {platoonTwo.Count}");
        }

        private void ShowResult(Platoon platoonOne, Platoon platoonTwo)
        {
            if(platoonRed.Count == 0 && platoonBlue.Count == 0)
                Console.WriteLine("There were no winners in this battle");
            else if (platoonRed.Count == 0)
                Console.WriteLine($"{platoonRed.Name} is Dead! {platoonBlue.Name} WIN");
            else if (platoonBlue.Count == 0)
                Console.WriteLine($"{platoonBlue.Name} is Dead! {platoonRed.Name} WIN");
        }

        private void RemoveDeadSoldiers(Platoon platoonOne, Platoon platoonTwo)
        {
            platoonRed.RemoveDeadSoldiers();
            platoonBlue.RemoveDeadSoldiers();
        }
    }
}
