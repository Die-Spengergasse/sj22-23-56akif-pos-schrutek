
namespace Spg.BasicsDemo.DomainModel.Model; 

public class Student : Person, IStudent
{
    public List<string> WhatEverNames { get; set; }
    public string Matrikelnummer { get; set; } = string.Empty;
    public Student() 
        : base(new DateTime(1977, 05, 13))
    { }

    public bool Subscribe()
    {
        throw new NotImplementedException();
    }

    public bool Unsubsribe()
    {
        throw new NotImplementedException();
    }
}
