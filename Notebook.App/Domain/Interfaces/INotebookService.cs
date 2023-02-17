using Notebook.App.Domain.Entities;

namespace Notebook.App.Domain.Interfaces;

public interface INotebookService
{
    Task<List<User>> GetAllAsync();
    
    Task<User?> GetByIdAsync(Guid id);
    
    Task<bool> AddAsync(User user, List<Phone> phones);
    
    Task DeleteAsync(Guid id);
    
    Task<bool> UpdateAsync(User user, List<Phone> phones);
    
    Task<bool> ExistByIdAsync(Guid id);
}