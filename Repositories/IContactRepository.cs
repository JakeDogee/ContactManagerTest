using ContactManagerTest.Models;

namespace ContactManagerTest.Repositories;

public interface IContactRepository
{
    Task<IEnumerable<Contact>> GetAllAsync();
    Task<Contact> GetByIdAsync(int id);
    Task AddAsync(Contact contact);
    Task UpdateAsync(Contact contact);
    Task DeleteAsync(int id);
}