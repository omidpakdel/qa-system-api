using Core.Services.Email;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Services.Email
{
    public class SmtpSettings : ISmtpSettings
    {
        private readonly IConfiguration _configuration;

        public SmtpSettings(IConfiguration configuration)
        {
            this._configuration = configuration;
        }

        public string Username => this._configuration["SmtpSettings:Username"];
        public string DisplayName => this._configuration["SmtpSettings:DisplayName"];
        public string Password => this._configuration["SmtpSettings:Password"];
        public string Host => this._configuration["SmtpSettings:Host"];
        public int Port => int.Parse(this._configuration["SmtpSettings:Port"]);
        public bool Ssl => bool.Parse(this._configuration["SmtpSettings:Ssl"]);
        public string TargetEmail => this._configuration["SmtpSettings:TargetEmail"];

        public IConfigurationSection GetConfigurationSection(string key)
        {
            return this._configuration.GetSection(key);
        }
    }
}