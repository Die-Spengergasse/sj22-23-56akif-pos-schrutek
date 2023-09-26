namespace Spg.BasicsDemo.DomainModel.Model;

public interface IStudent
{
    public string Matrikelnummer { get; set; }

    public bool Subscribe();

    public bool Unsubsribe();
}
