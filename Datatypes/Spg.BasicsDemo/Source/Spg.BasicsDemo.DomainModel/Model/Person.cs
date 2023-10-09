namespace Spg.BasicsDemo.DomainModel.Model; 

public class Person 
{
    private readonly int _age;

    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string EMail { get; set; }
    public Nullable<decimal> Salary { get; set; }

    public long SocialSecurityNumber { get; set; }

    public string ShortName =>
        LastName.Substring(0, 3).ToUpper();

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

    public Person()
    { }

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
        EMail = null;
        Salary = null;
    }

    public string GetFullName() 
        => $"{FirstName} - {LastName} : E-Mail {EMail}";

    public string FullName 
        => $"{FirstName} - {LastName}";

    public void CalcSalaryWhatEver()
    {
        string result = Salary.Value.ToString();
    }


}
