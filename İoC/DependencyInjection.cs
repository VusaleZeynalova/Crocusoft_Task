using DAL.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;


namespace IoC
{
    public static class DependencyInjection
    {

        public static void ServiceRegistration(this IServiceCollection services)
        {


            services.AddDbContext<DataContext>(options =>
            {
                options.UseSqlServer(Configuration.ConnectionString);

            });
            //.AddIdentity<StorageUser, StorageRole>()
            //.AddEntityFrameworkStores<DatabaseContext>();
        }
    }
}