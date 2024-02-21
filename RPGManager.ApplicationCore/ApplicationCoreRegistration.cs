using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using RPGManager.ApplicationCore.Behaviors;
using System.Reflection;

namespace RPGManager.ApplicationCore
{
    public static class ApplicationCoreRegistration
    {
        public static void RegisterApplicationCore(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        }
    }
}
