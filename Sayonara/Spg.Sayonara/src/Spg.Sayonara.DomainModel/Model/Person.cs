namespace Spg.Sayonara.DomainModel.Model
{
    public abstract class Person
    {
        public int Id { get; set; }
        public Guid Guid { get; set; }
        public Genders Gender { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public PhoneNumber PhoneNumber { get; set; } = default!;
        public EMail EMail { get; set; } = default!;

        protected Person() 
        { }
        public Person(Guid guid, Genders gender, string firstName, string lastName, PhoneNumber phoneNumber, EMail eMail)
        {
            Guid = guid;
            Gender = gender;
            FirstName = firstName;
            LastName = lastName;
            PhoneNumber = phoneNumber;
            EMail = eMail;
        }
    }
}
