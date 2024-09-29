using ContactManagerTest.Models;
using ContactManagerTest.Services;
using Microsoft.AspNetCore.Mvc;

namespace ContactManagerTest.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ContactController : ControllerBase
{
    private readonly IContactService _contactService;

    public ContactController(IContactService contactService)
    {
        _contactService = contactService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var contacts = await _contactService.GetAllContactsAsync();
        return Ok(contacts);
    }

    [HttpPost("upload")]
    public async Task<IActionResult> UploadCsv(IFormFile file)
    {
        await _contactService.ImportCsvAsync(file);
        return Ok();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] Contact contact)
    {
        if (id != contact.Id) return BadRequest();
        await _contactService.UpdateContactAsync(contact);
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _contactService.DeleteContactAsync(id);
        return Ok();
    }
}