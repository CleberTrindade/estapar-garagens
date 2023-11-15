using Estapar.Garagens.Infrastructure.Context;
using Estapar.Garagens.Infrastructure.ExternalServices.Interfaces;
using Estapar.Garagens.Infrastructure.ExternalServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Estapar.Garagens.Domain.Interfaces.Repositories;
using Estapar.Garagens.Infrastructure.Repositories;

namespace Estapar.Garagens.Infrastructure.IoC
{
    public static class DependencyInjection
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"), 
            b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

            //ExternalService
            services.AddScoped<IFormaPagamentoService, FormaPagamentoService>();
            services.AddScoped<IGaragemService, GaragemService>();
            services.AddScoped<IPassagemService, PassagemService>();

            //Repositories
            services.AddScoped<IPassagemRepository, PassagemRepository>();
            services.AddScoped<IFormaPagamentoRepository, FormaPagamentoRepository>();
            services.AddScoped<IGaragemRepository, GaragemRepository>();


            //return services;
        }
    }
}
