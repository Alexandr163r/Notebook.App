using Notebook.App.Domain.Entities;

namespace Notebook.App.Domain.Interfaces;

public interface IPhoneRepository
{
    Task DeleteAsync(Guid id);
    
    Task<bool> AddAsync(Guid useuId, List<Phone> phones);
}