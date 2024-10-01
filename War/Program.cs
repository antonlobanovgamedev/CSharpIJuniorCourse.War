namespace War
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Platoon platoonRed = new Platoon("RED");
            Platoon platoonBlue = new Platoon("BLUE");

            WriteInfo(platoonRed, platoonBlue);

            while (platoonRed.Count > 0 && platoonBlue.Count > 0)
            {
                platoonRed.Attack(platoonBlue);

                if (platoonBlue.Count == 0)
                    break;

                platoonBlue.Attack(platoonRed);

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
