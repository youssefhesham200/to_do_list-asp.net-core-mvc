using Microsoft.EntityFrameworkCore;
using to_do_list.Areas.Identity.Data;
using to_do_list.Contracts;
using to_do_list.Repository;

namespace to_do_list.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureSQL(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("to_do_listDbContextConnection") ?? throw new InvalidOperationException("Connection string 'to_do_listDbContextConnection' not found.");

            services.AddDbContext<to_do_listDbContext>(options => options.UseSqlServer(connectionString));
        }

        public static void ConfigureIdentity(this IServiceCollection services)
        {
            services.AddDefaultIdentity<AppUser>(options => options.SignIn.RequireConfirmedAccount = false)
             .AddEntityFrameworkStores<to_do_listDbContext>();
        }
        public static void ConfigureLifeTime(this IServiceCollection services)
        {
            services.AddScoped<IRepoMission, RepoMission>();
        }
    }
}
