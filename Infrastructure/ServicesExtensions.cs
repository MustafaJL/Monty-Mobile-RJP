using Infrastructure.IServices;
using Infrastructure.Repository.Base;
using Infrastructure.Repository.UnitOfWork;
using Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public static class ServicesExtensions
    {
        public static void AddRepositoriesFromAssembly(this IServiceCollection services, Assembly assembly)
        {
            var repositoryTypes = assembly.GetTypes()
                .Where(type => !type.IsAbstract &&
                               !type.IsInterface &&
                               type.GetInterfaces().Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IRepository<>)));

            foreach (var repositoryType in repositoryTypes)
            {
                var interfaceType = repositoryType.GetInterfaces()
                    .FirstOrDefault(i => i.Name == $"I{repositoryType.Name}");

                if (interfaceType != null)
                {
                    services.AddScoped(interfaceType, repositoryType);
                }
            }
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ITokenManager, TokenManager>();
        }
    }
}
