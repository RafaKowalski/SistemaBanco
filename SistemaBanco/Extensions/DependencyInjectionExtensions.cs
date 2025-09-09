using SistemaBanco.Application.BancoServices;
using SistemaBanco.Application.BoletoServices;
using SistemaBanco.Application.Mappers;
using SistemaBanco.Infra.Data.EF.Bancos;
using SistemaBanco.Infra.Data.EF.Boletos;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace SistemaBanco.Api.Extensions
{
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddTransient<IBancoService, BancoService>();
            services.AddTransient<IBoletoService, BoletoService>();

            return services;
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<IBancoRepository, BancoRepository>();
            services.AddTransient<IBoletosRepository, BoletoRepository>();

            return services;
        }

        public static IServiceCollection AddMapperConfig(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(BancoMapper), typeof(BoletoMapper));

            return services;
        }
    }
}
