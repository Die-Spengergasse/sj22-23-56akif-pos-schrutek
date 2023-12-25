namespace Spg.Inheritance.Demo.Model
{
    public class Person
    {
        public Person(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public void IsLegalAge() 
        {
            Console.WriteLine("Person.IsLegalAge()");
        }

        public virtual void VirtualDemo()
        {
            Console.WriteLine("Person.VirtualDemo() (virtual)");
        }
    }
}
