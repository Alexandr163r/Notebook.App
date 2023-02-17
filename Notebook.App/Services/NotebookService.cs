using Notebook.App.Domain.Entities;
using Notebook.App.Domain.Interfaces;

namespace Notebook.App.Services;

public class NotebookService : INotebookService
{
    private readonly IUserRepository _userRepository;

    private readonly IPhoneRepository _phoneRepository;

    public NotebookService(IUserRepository userRepository, IPhoneRepository phoneRepository)
    {
        _userRepository = userRepository;
        _phoneRepository = phoneRepository;
    }

    public async Task<List<User>> GetAllAsync()
    {
        var users = await _userRepository.GetAllAsync();

        return users;
    }

    public async Task<User?> GetByIdAsync(Guid id)
    {
        var user = await _userRepository.GetByIdAsync(id);

        return user;
    }

    public async Task<bool> AddAsync(User user, List<Phone> phones)
    {
        await _userRepository.AddAsync(user);
        
        await _phoneRepository.AddAsync(user.Id , phones);

        return true;
    }

    public async Task DeleteAsync(Guid id)
    {
        await _userRepository.DeleteAsync(id);
    }

    public async Task<bool> UpdateAsync(User user, List<Phone> phones)
    {
        await _userRepository.UpdateAsync(user.Id, user);
        
        await _phoneRepository.DeleteAsync(user.Id);
        
        await _phoneRepository.AddAsync(user.Id, phones);

        return true;
    }

    public async Task<bool> ExistByIdAsync(Guid id)
    {
        var result = await _userRepository.ExistByIdAsync(id);

        return result;
    }
}