using CommunereTest.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CommunereTest.Persistence
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
        
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<ContactDetails> ContactDetails { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<EmailVerificationCode> EmailVerificationCodes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }
    }
}