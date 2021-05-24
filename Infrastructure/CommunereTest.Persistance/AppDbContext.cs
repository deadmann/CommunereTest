using CommunereTest.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CommunereTest.Persistance
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
        
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<ContactDetails> ContactDetails { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}