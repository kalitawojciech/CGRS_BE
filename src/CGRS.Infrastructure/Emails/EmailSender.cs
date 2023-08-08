using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace CGRS.Infrastructure.Emails
{
    public class EmailSender
    {
        private readonly IConfiguration _configuration;

        public EmailSender(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task SendEmailAsync(string recipientEmail, string subject, string message)
        {

        }
    }
}
