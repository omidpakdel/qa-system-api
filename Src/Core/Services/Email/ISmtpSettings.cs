using Microsoft.Extensions.Configuration;

namespace Core.Services.Email
{
    public interface ISmtpSettings
    {
        public string Username { get; }
        public string DisplayName { get; }
        public string Password { get; }
        public string Host { get; }
        public int Port { get; }
        public bool Ssl { get; }
        public string TargetEmail { get;}
        IConfigurationSection GetConfigurationSection(string key);
    }
}