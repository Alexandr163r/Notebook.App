using Microsoft.EntityFrameworkCore;
using Notebook.App.Domain.Entities;
using Notebook.App.Domain.Interfaces;

namespace Notebook.App.Data;

public class UserRepository : IUserRepository
{
    private readonly NotebookDbContext _dbContext;

    public UserRepository(NotebookDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<List<User>> GetAllAsync()
    {
        var users = _dbContext.Users.Include(u => u.Phones).ToList();

        return (users);
    }
    
    public Task<User> GetByIdAsync(Guid id)
    {
        var result = _dbContext.Users.Include(u => u.Phones).FirstOrDefault(x => x.Id == id);

        return Task.FromResult(result)!;
    }

    public async Task AddAsync(User user)
    {
        user.DateOfCreation = DateTime.Now;

        await _dbContext.Users.AddAsync(user);

        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var user = _dbContext.Users.Find(id);

        _dbContext.Remove(user);
        
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(Guid id, User entity)
    {
        var user = _dbContext.Users.First(user => user.Id == entity.Id);
        user.Name = entity.Name;
        user.Surname = entity.Surname;
        user.DateOfModification = DateTime.Now;
        user.YearOfBirth = entity.YearOfBirth;

        _dbContext.Users.Update(user);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<bool> ExistByIdAsync(Guid id)
    {
        var result = await _dbContext.Users.AnyAsync(u => u.Id == id);
        
        return result;
    }
}