using Application.Interfaces;
using Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection
            services, IConfiguration configuration)
        {
            services.AddDbContext<DataContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"), b => { b.EnableRetryOnFailure(); b.MigrationsAssembly("API"); }));


            // identity
            services.AddDefaultIdentity<AppUser>()
                            .AddRoles<IdentityRole>()
                            .AddEntityFrameworkStores<DataContext>();

            var builder = services.AddIdentityCore<AppUser>(o =>
            {
                // configure identity options
                o.Password.RequireDigit = false;
                o.Password.RequireLowercase = false;
                o.Password.RequireUppercase = false;
                o.Password.RequireNonAlphanumeric = false;
                o.Password.RequiredLength = 6;
            });

            builder = new IdentityBuilder(builder.UserType, typeof(IdentityRole), builder.Services);
            builder.AddEntityFrameworkStores<DataContext>().AddDefaultTokenProviders();

            services.AddScoped<IDataContext, DataContext>();

            return services;
        }
    }
}
