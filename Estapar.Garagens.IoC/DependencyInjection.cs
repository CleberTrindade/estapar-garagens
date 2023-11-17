using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Estapar.Garagens.Infrastructure.ExternalServices;
using Microsoft.EntityFrameworkCore;
using Estapar.Garagens.Infrastructure.Context;
using Estapar.Garagens.Infrastructure.ExternalServices.Interfaces;
using Estapar.Garagens.Domain.Interfaces.Repositories;
using Estapar.Garagens.Infrastructure.Repositories;
using Estapar.Garagens.Application.Interfaces;
using Estapar.Garagens.Application.Services;
using Estapar.Garagens.Application.Mappings;

namespace Estapar.Garagens.IoC
{
    public static class DependencyInjection
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
            b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

            services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));


            //ExternalService
            services.AddScoped<IFormaPagamentoExternalService, FormaPagamentoExternalService>();
            services.AddScoped<IGaragemExternalService, GaragemExternalService>();
            services.AddScoped<IPassagemExternalService, PassagemExternalService>();

            //Repositories
            services.AddScoped<IPassagemRepository, PassagemRepository>();
            services.AddScoped<IFormaPagamentoRepository, FormaPagamentoRepository>();
            services.AddScoped<IGaragemRepository, GaragemRepository>();


            //Application Services 
            services.AddScoped<IListagemCarrosService, ListagemCarrosService>();
            services.AddScoped<IFechamentoService, FechamentoService>();
            services.AddScoped<ITempoMedioEstadiaService, TempoMedioEstadiaService>();
            services.AddAutoMapper(typeof(DomainToDtoProfile));
        }
    }
}
