Console.WriteLine("Hello, World! without Top Level Statement");

int i = 5;

Console.WriteLine(i);
Person p = new Person();

class Person
{
    <<<<<<<
    public int Id { get; set; }
    =======
    public int ID { get; set; }
    >>>>>>>

    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
}