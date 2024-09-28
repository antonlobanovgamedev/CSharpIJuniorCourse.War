
namespace War
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
        }
    }      

    internal class Infantryman : Soldier
    {
        public Infantryman(int health, int damage, int armor) : base(100, 15, 6) { }               
    }
}
