namespace Notebook.App.Domain.Entities;

public class Phone
{
    public Guid PhoneId { get; set; } = Guid.NewGuid();
    
    public string PhoneNumber { get; set; } = string.Empty;
    
    public Guid UserId { get; set; }

    public virtual User User { get; set; } = null!;
}