using Spg.Inheritance.Demo.Model;
using Spg.Inheritance.Demo.Model.Abstract;

// Alle Ausgaben kommen aus Person
Console.WriteLine();
Console.WriteLine("(Instanz: Person, Typ: Person)");
Person person = new Person("Anna", "Theke");
person.IsLegalAge();
person.VirtualDemo();

// Alle Ausgaben kommen aus Student
Console.WriteLine();
Console.WriteLine("(Instanz: Student, Typ: Student)");
Student student = new Student("Anna", "Theke");
student.IsLegalAge();
student.VirtualDemo();

// Alle Ausgaben kommen aus Teacher
Console.WriteLine();
Console.WriteLine("(Instanz: Teacher, Typ: Teacher)");
Teacher teacher = new Teacher("Anna", "Theke", 123M);
teacher.IsLegalAge();
teacher.VirtualDemo();

// new greift auf die Basisklasse zurück, override nicht.
Console.WriteLine();
Console.WriteLine("(Instanz: Teacher, Typ: Person)");
Person p2 = new Teacher("Anna", "Theke", 456M);
p2.IsLegalAge();
p2.VirtualDemo();

// new greift auf die Basisklasse zurück, override nicht.
Console.WriteLine();
Console.WriteLine("(Instanz: Student, Typ: Person)");
Person p3 = new Student("Anna", "Theke");
p3.IsLegalAge();
p3.VirtualDemo();

Console.WriteLine("-----------------------------------------");

Console.WriteLine();
Console.WriteLine("(Dreamliner)");
FlightDevice dl = new DreamLiner(228);
dl.Start();
dl.Land();
dl.PrintPassengers();

Console.WriteLine();
Console.WriteLine("(Helicopter)");
FlightDevice hc = new Helicopter();
hc.Start();
hc.Land();
hc.PrintPassengers();
