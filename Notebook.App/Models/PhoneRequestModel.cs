using System.ComponentModel.DataAnnotations;

namespace Notebook.App.Models;

public class PhoneRequestModel
{
    [RegularExpression(@"^((8|\+7)[\- ]?)?(\(?\d{3}\)?[\- ]?)?[\d\- ]{7,10}$", ErrorMessage = "неверно указан номер")]
    public string PhoneNumber { get; set; } = string.Empty;
}