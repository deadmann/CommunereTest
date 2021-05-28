using CommunereTest.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CommunereTest.Persistence.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasOne(o => o.CreatedBy)
                .WithMany()
                .HasForeignKey(f => f.CreatedById);

            builder.HasOne(o => o.UpdatedBy)
                .WithMany()
                .HasForeignKey(f => f.UpdatedById);
        }
    }
}