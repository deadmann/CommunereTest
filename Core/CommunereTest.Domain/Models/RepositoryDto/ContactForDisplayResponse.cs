using System;
using CommunereTest.Domain.Entities;

namespace CommunereTest.Domain.Models.RepositoryDto
{
    public class ContactForDisplayResponse
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public DateTime? BirthDate { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }
}