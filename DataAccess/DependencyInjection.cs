using DataAccess.Context;
using EntitiesProject.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Scrutor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDataAccess(this IServiceCollection services, IConfiguration configuration)
        {
            string connectionString = configuration.GetConnectionString("SqlServerConnection");
            services.AddDbContext<ApplicationContext>(opt =>
            {
                opt.UseSqlServer(connectionString);
            });

            services.AddIdentityCore<AppUser>(cfg =>
            {
                cfg.Password.RequireNonAlphanumeric = true;
            }).AddEntityFrameworkStores<ApplicationContext>();
            //unitofwork çağrıldığında context nesnesin yenile
            services.AddScoped<IUnitOfWork>(sv => sv.GetRequiredService<ApplicationContext>());

            //services.AddScoped<ICategoryRepository, CategoryRepository>();
            //services.AddScoped<IProductRepository, ProductRepository>();
            //services.AddScoped<IUserRoleRepository, UserRoleRepository>();

            //birden fazla dependency injectionlar için otomatikleştirmeler iiçin kütüphane 
            //scrutor kütüphanesi

            ///scan metotdu ile nerede olduğu taranır. publicOnly false vermemmizin sebebi bizim classlarımız internal olduğu için 
            ///usingRegistrationStrategy var olanları atla demek daha öncesinden tanımladıklarımızı 
            /////AsMatchingInterface interfacelerini elde etmek için 
            ///WithScopedLifetime instance türetilmesi sağlar.
            services.Scan(selector => selector.FromAssemblies(
                typeof(DependencyInjection).Assembly).AddClasses(publicOnly: false)
                .UsingRegistrationStrategy(RegistrationStrategy.Skip)
                .AsMatchingInterface()
                .WithScopedLifetime());

            return services;

        }
    }
}
