using ContactProject.Entities;
using ContactProject.EntityConfigurations;
using Microsoft.EntityFrameworkCore;

namespace ContactProject.Data
{
    public class ContactDbContext:DbContext 
    {
        public ContactDbContext(DbContextOptions<ContactDbContext> options) : base(options)
        {
        }
        public DbSet<Contact> Contact { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ContactEntityConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
