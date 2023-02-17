using Notebook.App.Domain.Entities;

namespace Notebook.App.Domain.Interfaces;

public interface IUserRepository
{
    Task<List<User>> GetAllAsync();
    
    Task<User?> GetByIdAsync(Guid id);
    
    Task AddAsync(User user);
    
    Task DeleteAsync(Guid id);
    
    Task UpdateAsync(Guid id, User entity);
    
    Task<bool> ExistByIdAsync(Guid id);
}