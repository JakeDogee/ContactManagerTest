using ContactManagerTest.Models;
using ContactManagerTest.Repositories;

namespace ContactManagerTest.Services;

public class ContactService : IContactService
{
    private readonly IContactRepository _repository;

    public ContactService(IContactRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Contact>> GetAllContactsAsync()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<Contact> GetContactByIdAsync(int id)
    {
        return await _repository.GetByIdAsync(id);
    }

    public async Task AddContactAsync(Contact contact)
    {
        await _repository.AddAsync(contact);
    }

    public async Task UpdateContactAsync(Contact contact)
    {
        await _repository.UpdateAsync(contact);
    }

    public async Task DeleteContactAsync(int id)
    {
        await _repository.DeleteAsync(id);
    }

    public async Task ImportCsvAsync(IFormFile file)
    {
        using (var reader = new StreamReader(file.OpenReadStream()))
        {
            while (!reader.EndOfStream)
            {
                var line = await reader.ReadLineAsync();
                var values = line.Split(',');

                var contact = new Contact
                {
                    Name = values[0],
                    DateOfBirth = DateTime.Parse(values[1]),
                    Married = bool.Parse(values[2]),
                    Phone = values[3],
                    Salary = decimal.Parse(values[4])
                };

                await _repository.AddAsync(contact);
            }
        }
    }
}