using CommunereTest.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CommunereTest.Persistence.Configurations
{
    public class ContactConfiguration:IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> builder)
        {
            builder.HasOne(o => o.User)
                .WithMany(m => m.Contacts)
                .HasForeignKey(f => f.UserId)
                .IsRequired();
        }
    }
}