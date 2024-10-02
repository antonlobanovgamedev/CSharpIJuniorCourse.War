namespace War
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Platoon platoonRed = new Platoon("RED", 4, 2, 5, 2);
            Platoon platoonBlue = new Platoon("BLUE", 3, 5, 2, 5);

            WriteInfo(platoonRed, platoonBlue);

            while (platoonRed.Count > 0 && platoonBlue.Count > 0)
            {
                platoonRed.Attack(platoonBlue);
                platoonBlue.RemoveDeadSoldiers();

                if (platoonBlue.Count == 0)
                    break;

                platoonBlue.Attack(platoonRed);
                platoonRed.RemoveDeadSoldiers();

                WriteInfo(platoonRed, platoonBlue);
            }

            if(platoonRed.Count == 0)
                Console.WriteLine($"{platoonRed.Name} is Dead! {platoonBlue.Name} WIN");

            if (platoonBlue.Count == 0)
                Console.WriteLine($"{platoonBlue.Name} is Dead! {platoonRed.Name} WIN");
        }

        static void WriteInfo(Platoon platoonOne, Platoon platoonTwo)
        {
            Console.WriteLine($"{platoonOne.Name} : {platoonOne.Count} - {platoonTwo.Name} : {platoonTwo.Count}");
        }
    }      
}
