using CommunereTest.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CommunereTest.Persistence.Configurations
{
    public class EmailVerificationCodeConfiguration:IEntityTypeConfiguration<EmailVerificationCode>
    {
        public void Configure(EntityTypeBuilder<EmailVerificationCode> builder)
        {
            builder.HasOne(o => o.User)
                .WithMany()
                .HasForeignKey(f => f.UserId)
                .IsRequired();
            
            builder.HasOne(o => o.CreatedBy)
                .WithMany()
                .HasForeignKey(f => f.CreatedById);

            builder.HasOne(o => o.UpdatedBy)
                .WithMany()
                .HasForeignKey(f => f.UpdatedById);
        }
    }
}