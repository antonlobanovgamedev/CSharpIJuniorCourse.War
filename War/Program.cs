using System.Runtime.Versioning;

namespace War
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Platoon platoonRed = new Platoon("RED", 1);
            Platoon platoonBlue = new Platoon("BLUE", 16);

            while (platoonRed.Count > 0 && platoonBlue.Count > 0)
            {
                platoonRed.Attack(platoonBlue);

                if (platoonBlue.Count == 0)
                    break;

                platoonBlue.Attack(platoonRed);
            }

            if(platoonRed.Count == 0)
                Console.WriteLine($"{platoonRed.Name} is Dead! {platoonBlue} WIN");

            if (platoonBlue.Count == 0)
                Console.WriteLine($"{platoonBlue.Name} is Dead! {platoonRed} WIN");
        }
    }      
}
