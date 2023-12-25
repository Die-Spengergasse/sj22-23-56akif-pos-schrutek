using Spg.Linq.Demo;

MyList<Student> _students = new MyList<Student>()
{
    new Student() { Id=1, FirstName="Martin", LastName="Schrutek", Age=46 },
    new Student() { Id=2, FirstName="Susanne", LastName="Mayer", Age=20 },
    new Student() { Id=3, FirstName="Hans", LastName="Maier", Age=10 },
    new Student() { Id=6, FirstName="Julia", LastName="Meier", Age=23 },
    new Student() { Id=7, FirstName="Alex", LastName="Müller", Age=16 },
    new Student() { Id=9, FirstName="Petra", LastName="Kohl", Age=17},
    new Student() { Id=9, FirstName="Anna", LastName="Schmid", Age=19},
    new Student() { Id=9, FirstName="Anton", LastName="Kohl", Age=3},
};

//var filtered = _students
//    .Where(s => s.FirstName.ToLower().StartsWith("a"))
//    .OrderBy(s => s.LastName)
//    .Select(s => new StudentDto(s.FirstName));
//var result = from s in _students
//             where s.FirstName.ToLower().StartsWith("a")
//             select new StudentDto(s.FirstName);

Console.WriteLine(_students.Where(s => s.Age > 20).OrderBy(s => s.LastName));

var resultList = _students.Filter(s => s.LastName.Contains("e"));


static bool LastNameContains(Student s)
{
    return s.LastName.Contains("a");
}
static bool AgeGT(Student s)
{
    return s.Age > 17;
}
static bool AgeLTE(Student s)
{
    return s.Age <= 17;
}

foreach (var student in resultList)
{
    Console.WriteLine($"{student.Id} | {student.FirstName} {student.LastName} ({student.Age})");
}

