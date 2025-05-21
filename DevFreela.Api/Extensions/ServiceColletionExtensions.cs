using DevFreela.Application.Services.Implementation;
using DevFreela.Application.Services.Interface;
using DevFreela.Core.Repositories;
using DevFreela.Core.Services;
using DevFreela.Infrastructure.Persistence.Repositories;
using DevFreela.Infrastructure.Services.Auth;
using DevFreela.Infrastructure.Services.MessageBus;
using DevFreela.Infrastructure.Services.Payments;
using Microsoft.Extensions.DependencyInjection;

namespace DevFreela.Api.Extensions
{
    public static class ServiceColletionExtensions
    {

        public static IServiceCollection AddInfrastructure(this IServiceCollection services) {
            services.AddScoped<IPaymentService, PaymentService>();

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ISkillRepository, SkillRepository>();
            services.AddScoped<IProjectRepository, ProjectRepository>();

            services.AddScoped<IProjectService, ProjectService>();
            services.AddScoped<ISkillService, SkillService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAuthService, AuthService>();

            services.AddScoped<IMessageBusService, MessageBusService>();
            
            return services;
        }
    }
}
