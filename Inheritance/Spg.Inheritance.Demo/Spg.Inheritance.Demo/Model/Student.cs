namespace Spg.Inheritance.Demo.Model
{
    public class Student : Person
    {
        public Student(string firstName) 
            : base(firstName, "Schrutek")
        { }

        public new void IsLegalAge()
        {
            Console.WriteLine("Student.IsLegalAge()");
        }

        public new void VirtualDemo()
        {
            Console.WriteLine("Student.VirtualDemo() (new)");
        }
    }
}
