using StylistPro.Compra.Application.Services;
using StylistPro.Compra.Data.AppData;
using StylistPro.Compra.Data.Repositories;
using StylistPro.Compra.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace StylistPro.Compra.IoC
{
    public static class Bootstrap
    {
        public static void Start(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationContext>(x => {
                x.UseOracle(configuration["ConnectionStrings:Oracle"]);
            });

            services.AddTransient<IComprasRepository, ComprasRepository>();
            services.AddTransient<IComprasApplicationService, ComprasApplicationService>();

        }
    }
}
