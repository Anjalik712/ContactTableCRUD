using ContactProject.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ContactProject.EntityConfigurations
{
    public class ContactEntityConfiguration : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x=>x.FirstName).IsRequired(true).HasMaxLength(50);
            builder.Property(x=>x.MiddleName).HasMaxLength(50);
            builder.Property(x=>x.LastName).HasMaxLength(50);
            builder.Property(x=>x.Age).IsRequired(true);
            builder.Property(x => x.DOB).HasColumnType("date");
            builder.Property(x => x.CreatedBy);
            builder.Property(x => x.CreatedDate);
            builder.Property(x => x.ModifiedBy);
            builder.Property(x => x.ModifiedDate);
        }
    }
}
