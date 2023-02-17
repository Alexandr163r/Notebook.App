using System.ComponentModel.DataAnnotations;

namespace Notebook.App.Models;

public class UserRequestModel
{
    [Required]
    [MaxLength(50), MinLength(1)]

    public string Name { get; set; } = string.Empty;
    
    [Required]
    [MaxLength(50), MinLength(1)]
    public string Surname { get; set; } = string.Empty;
    
    [Range(1907, 2023, ErrorMessage = "Введите верную дату рождения")]
    public int YearOfBirth { get; set; }

    public List<PhoneRequestModel> PhoneInformations { get; set; }
}