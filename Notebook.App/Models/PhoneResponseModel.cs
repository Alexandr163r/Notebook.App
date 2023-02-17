namespace Notebook.App.Models;

public class PhoneResponseModel
{
    public Guid PhoneId { get; set; }
    
    public string PhoneNumber { get; set; } = string.Empty;
    
    public Guid UserId { get; set; }
}