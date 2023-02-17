namespace Notebook.App.Models;

public class UserResponseModel
{
    public Guid Id { get; set; }
        
    public string Name { get; set; } = string.Empty;
    
    public string Surname { get; set; } = string.Empty;

    public int YearOfBirth { get; set; }

    public List<PhoneResponseModel> Phones = new();
}
