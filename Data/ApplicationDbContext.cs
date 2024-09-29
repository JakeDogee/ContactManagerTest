using ContactManagerTest.Models;
using Microsoft.EntityFrameworkCore;

namespace ContactManagerTest.Data;

public class ApplicationDbContext : DbContext
{
    public DbSet<Contact> Contacts { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }
}