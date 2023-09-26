using Spg.BasicsDemo.DomainModel.Model;

namespace Spg.BasicsDemo.App2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            Person p = new Person(DateTime.Now);
            p.FirstName = "Martin";
            string x = p.LastName;

            //p.BirthDate = DateTime.Now;

            Console.WriteLine(x);

            p.FirstName = "Test";
            Console.Write(p.FirstName);

            int i = 12;
            Console.WriteLine(i);

            decimal tax = 20.25M;

            string input = Console.ReadLine();
        }
    }
}
