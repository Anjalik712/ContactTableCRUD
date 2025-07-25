using ContactProject.Entities;
using ContactProject.EntityConfigurations;
using Microsoft.EntityFrameworkCore;

namespace ContactProject.Data;

/// <summary>
/// The ContactDbContext class represents the database context for the Contact project.
/// It manages the Contact entity and handles configuration through EF Core.
/// </summary>
public class ContactDbContext : DbContext
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ContactDbContext"/> class
    /// using the specified options.
    /// </summary>
    /// <param name="options">The options to configure the DbContext.</param>
    public ContactDbContext(DbContextOptions<ContactDbContext> options) : base(options)
    {
    }

    /// <summary>
    /// Gets or sets the Contacts table in the database.
    /// </summary>
    public DbSet<Contact> Contact { get; set; }

    /// <summary>
    /// Configures the entity mappings and relationships using Fluent API.
    /// This method is called by the framework when the model is being created.
    /// </summary>
    /// <param name="modelBuilder">The builder used to construct the model for the context.</param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Apply custom configuration for the Contact entity
        modelBuilder.ApplyConfiguration(new ContactEntityConfiguration());

        // Call the base implementation to apply default configurations
        base.OnModelCreating(modelBuilder);
    }
}
