namespace Testing
{
    class Program
    {
        static void Main(string[] args)
        {
            A a = new B(100);
            B b = new B(99);
            b = (B)a;
            Console.WriteLine(b.Property);
            Console.WriteLine(b.PropertyInB);
        }
    }
    class A
    {
        public A(int property) =>
            Property = property;
        public int Property { get; set; }
    }
    class B : A
    {
        public B(int property) : base(property)
        {
            Property = property;
            PropertyInB = 25;
        }
        public int PropertyInB { get; set; }
        public int Property { get; set; }
    }
}
