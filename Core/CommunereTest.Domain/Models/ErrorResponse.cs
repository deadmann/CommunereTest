using System.Collections.Generic;

namespace CommunereTest.Domain.Models
{
    public class ErrorResponse
    {
        public string Title { get; set; }
        public IDictionary<string, string[]> Errors { get; set; }
    }
}
