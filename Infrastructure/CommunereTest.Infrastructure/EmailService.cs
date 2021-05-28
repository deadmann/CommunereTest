using System;
using System.Threading;
using System.Threading.Tasks;
using CommunereTest.Domain.Interfaces;
using MailKit.Security;
using MimeKit;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace CommunereTest.Infrastructure
{
    public class EmailService : IEmailService
    {
	    private readonly IWebHostEnvironment _currentEnvironment;

	    public EmailService(IWebHostEnvironment currentEnvironment)
	    {
		    _currentEnvironment = currentEnvironment;
	    }

	    public async Task SendAsync(string recipientsName, string recipientEmail,
            string subject, string content, CancellationToken cancellationToken)
        {
	        if (_currentEnvironment.IsDevelopment())
	        {
		        Console.WriteLine(content);
		        return;
	        }
		        
	        var fromMail = "NoReply@communere.com";
	        var fromPassword = "No Reply Email Password";
			var message = new MimeMessage();
			message.From.Add(new MailboxAddress("Communere", fromMail));
			message.To.Add(new MailboxAddress(recipientsName, recipientEmail));
			message.Subject = subject;

			message.Body = new TextPart("plain")
			{
				Text = content
			};

            using var client = new SmtpClient();

            await client.ConnectAsync("smtp.gmail.com", 587, SecureSocketOptions.Auto, cancellationToken);
            await client.AuthenticateAsync(fromMail, fromPassword, cancellationToken);

            await client.SendAsync(message, cancellationToken);
            await client.DisconnectAsync(true, cancellationToken);
        }
    }
}
