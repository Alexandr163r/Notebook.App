using Notebook.App.Domain.Entities;
using Notebook.App.Domain.Interfaces;

namespace Notebook.App.Data;

public class PhoneRepository : IPhoneRepository
{
    private readonly NotebookDbContext _dbContext;

    public PhoneRepository(NotebookDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task DeleteAsync(Guid id)
    {
        var phones = _dbContext.Phones.Where(phone => phone.UserId == id).ToList();
        _dbContext.RemoveRange(phones);
        await _dbContext.SaveChangesAsync();
    }
    
    public async Task<bool> AddAsync(Guid userId, List<Phone> phones)
    {
        try
        {
            foreach (var phone in phones)
            {
                phone.UserId = userId;
            }
            
            await _dbContext.Phones.AddRangeAsync(phones);

            await _dbContext.SaveChangesAsync();

            return true;
        }
        catch (Exception e)
        {
            throw new Exception(e.ToString());
        }
    }
}