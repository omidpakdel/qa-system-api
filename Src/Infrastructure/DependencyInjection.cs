using Core.Repositories;
using Core.Repositories.Base;
using Core.Services.Email;
using Infrastructure.Repositories;
using Infrastructure.Repositories.Base;
using Infrastructure.Services.Email;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
        public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IQuestionRepository, QuestionRepository>();
            services.AddTransient<IAnswerRepository, AnswerRepository>();
            services.AddTransient<IUserAnswerRepository, UserAnswerRepository>();

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped(typeof(IUserRepository), typeof(UserRepository));
            services.AddScoped(typeof(IQuestionRepository), typeof(QuestionRepository));
            services.AddScoped(typeof(IAnswerRepository), typeof(AnswerRepository));
            services.AddScoped(typeof(IUserAnswerRepository), typeof(UserAnswerRepository));

            services.AddSingleton<ISmtpSettings, SmtpSettings>();
            services.AddScoped<IEmailService, EmailService>();
            
            return services;
        }
    }

}