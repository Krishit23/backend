using SavorySeasons.Backend.Email.Models;
using SavorySeasons.Backend.Email.Services;

namespace SavorySeasons.Backend
{
    public static class ServiceCollectionExtensions
    {
        private const string EmailConfigSection = "Email";

        public static IServiceCollection AddEmailServices(this IServiceCollection services, IConfiguration configuration)
        {
            var emailConfiguration = configuration.GetSection(EmailConfigSection).Get<EmailConfiguration>();
            services.AddSingleton(emailConfiguration);

            services.AddScoped<IEmailService, EmailService>();
            return services;
        }
    }
}
