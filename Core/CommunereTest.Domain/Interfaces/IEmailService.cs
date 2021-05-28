using System.Threading;
using System.Threading.Tasks;

namespace CommunereTest.Domain.Interfaces
{
    public interface IEmailService
    {
        Task SendAsync(string recipientsName, string recipientEmail,
            string subject, string content, CancellationToken cancellationToken);
    }
}
