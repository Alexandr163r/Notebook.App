using Microsoft.EntityFrameworkCore;
using Notebook.App.Domain.Entities;

namespace Notebook.App.Data;

public class NotebookDbContext : DbContext
{
    public NotebookDbContext(DbContextOptions<NotebookDbContext> options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }

    public DbSet<Phone> Phones { get; set; }
}