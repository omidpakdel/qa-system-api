using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Services.Email
{
    public interface IEmailService
    {
        Task SendEmail(User user, Dictionary<string, string> dictionary);
    }
}