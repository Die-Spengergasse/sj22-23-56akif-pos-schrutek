namespace Spg.Inheritance.Demo.Model
{
    public class Teacher : Person
    {
        public Teacher(string firstName, string lastName)
            : base(firstName, lastName)
        { }

        public Teacher(string firstName, string lastName, decimal income)
            : this(firstName, lastName)
        {
            Income = income;
        }

        public decimal Income { get; set; }

        public new void IsLegalAge()
        {
            Console.WriteLine("Teacher.IsLegalAge()");
        }

        public override void VirtualDemo()
        {
            Console.WriteLine("Teacher.VirtualDemo() (override)");
        }
    }
}
