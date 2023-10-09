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

            Person p2 = new Person() 
            { 
                FirstName = "Martin", 
                LastName = "Schrutek", 
                EMail = "schrutek@spengergasse.at"
            };


            List<Person> personList = new List<Person>()
            {
                new Person() { FirstName = "Martin1", LastName = "Schrutek1", EMail = "schrutek1@spengergasse.at" },
                new Person() { FirstName = "Martin2", LastName = "Schrutek2", EMail = "schrutek2@spengergasse.at" },
                new Person() { FirstName = "Martin3", LastName = "Schrutek3", EMail = "schrutek3@spengergasse.at" },
                new Person() { FirstName = "Martin4", LastName = "Schrutek4", EMail = "schrutek4@spengergasse.at" },
                new Person() { FirstName = "Martin5", LastName = "Schrutek5", EMail = "schrutek5@spengergasse.at" },
            };


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
