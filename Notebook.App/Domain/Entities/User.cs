namespace Notebook.App.Domain.Entities;

public class User
{
    public Guid Id { get; set; } = Guid.NewGuid();
    
    public string Name { get; set; } = string.Empty;
    
    public string Surname { get; set; } = string.Empty;

    public int YearOfBirth { get; set; }

    public List<Phone> Phones { get; set; } = new();
    
    public DateTime DateOfCreation { get; set; }

    public DateTime DateOfModification { get; set; }
}