using Spg.BasicsDemo.DomainModel.Model;

namespace Spg.BasicsDemo.DomainModel
{
    public class Class1
    {
        public static void Main(string[] args)
        {
            SchoolClass sc = new SchoolClass() { RoomNumber = "B5.09" };
            sc.RoomNumber = "4711";

        }
    }
}