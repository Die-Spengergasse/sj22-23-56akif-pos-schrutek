using Spg.Collections.Demo;
using Spg.Collections.Demo.InterfacesDemo;

#region -- School Cass Example -------------------------------------------

SchoolClass scB401 = new SchoolClass() { RoomNumber = "B4.01" };
MyList<SchoolClass> schoolClasses = new MyList<SchoolClass>()
{
    scB401,
    new SchoolClass() { RoomNumber = "B4.02" },
    new SchoolClass() { RoomNumber = "B4.02" },
    new SchoolClass() { RoomNumber = "B4.03",
        Students = new List<Student>()
        {
            new Student() { FirstName="Martin", Lastname="Schrutek" },
            new Student() { FirstName="Martin1", Lastname="Schrutek1" },
            new Student() { FirstName="Martin2", Lastname="Schrutek2" },
            new Student() { FirstName="Martin3", Lastname="Schrutek3" },
            new Student() { FirstName="Martin4", Lastname="Schrutek4" },
        }
    }
};

//schoolClasses[0].Students.Add... // gibts nicht
schoolClasses.Add(new SchoolClass() { RoomNumber = "B4.04" });
//schoolClasses.Remove(scB401);

//List<SchoolClass> schoolClasses = new List<SchoolClass>()
//{
//    new SchoolClass("B4.01", new(Colors.Red, "", "", null)),
//    new SchoolClass("B4.02", new(Colors.Red, "", "", null)),
//    new SchoolClass("B4.03", new(Colors.Red, "", "", null))
//};
//schoolClasses.Remove(new SchoolClass("B4.01", new(Colors.Red, "", "", null)));

SchoolClass selectedScoolClass = schoolClasses["B4.02"]!;


Dictionary<string, Student> students = new()
{
    { "S1", new Student() { FirstName = "Martin", Lastname = "Schrutek" } }
};

//Code dazwischen

students.Add("S2", new Student() { FirstName = "Martin2", Lastname = "Schrutek2" });
students.Remove("S2");

foreach (SchoolClass item in schoolClasses)
{
    Console.WriteLine($"{item.RoomNumber}");
    foreach (Student student in item.Students)
    {
        Console.WriteLine($"   {student.FirstName} {student.Lastname}");
    }
}

#endregion -- School Cass Example -------------------------------------------

# region -- Interface Example -------------------------------------------

List<IUfo> ufos = new()
{
    new JoboJet() { Seats=120 },
    new JoboJet() { Seats = 300 },
    new JoboJet() { Seats = 456 },
    new JoboJet() { Seats = 123 },
    new Helicopter() { Seats=2 },
    new Helicopter() { Seats=4 },
};

foreach (IUfo ufo in ufos)
{
    ufo.TakeOff();
}

Console.ReadLine();

# endregion -- Interface Example -------------------------------------------
