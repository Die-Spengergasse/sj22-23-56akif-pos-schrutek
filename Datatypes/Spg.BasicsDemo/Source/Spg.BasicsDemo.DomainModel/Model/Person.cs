namespace Spg.BasicsDemo.DomainModel.Model; 

public class Person 
{
    private readonly int _age;

    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string EMail { get; set; }

    public long SocialSecurityNumber { get; set; }

    public int MyProperty
    {
        get { return myVar; }
        set 
        {
            if (value < 0)
            {
                throw new ArgumentException("Darf nicht kleiner als 0 sein!");
            }
            myVar = value; 
        }
    }
    private int myVar;

    public DateTime BirthDate { get; }

    //public Person()
    //{ }

    public Person(DateTime birthDate)
    {
        BirthDate = birthDate;
    }

    public Person(string firstName, 
        string lastName, 
        string asdasd, 
        string qweqweqew, 
        string wrtweerwwerwer, 
        string sdsffsdsdfdsd, 
        string iopiuiopiopio, 
        string sadasdsadadsdas)
    {
        FirstName = firstName;
        LastName = lastName;
    }

    public string GetFullName()
    {
        //StringBuilder sb = new StringBuilder();
        //sb.Append(FirstName);

        var i = new Int64(); 

        return $"{FirstName} - {LastName} : E-Mail {EMail}";
    }
}
