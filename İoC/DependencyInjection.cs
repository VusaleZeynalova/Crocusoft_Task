using BLL.AuthServices.Abstract;
using BLL.AuthServices.Concrete;
using DAL.Abstract;
using DAL.Concrete;
using DAL.Context;
using DAL.UnitOfWorks;
using Entity.MemberShip;
using Microsoft.AspNetCore.Identity;
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

            })
            .AddIdentity<AppUser, AppRole>()
            .AddEntityFrameworkStores<DataContext>();
            services.AddAutoMapper(typeof(BLL.Mapper.AutoMapper));
            services.Configure<IdentityOptions>(options =>
            {
                // Password settings.
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 6;
                // options.Password.RequiredUniqueChars = 1;

                // Lockout settings.
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.AllowedForNewUsers = true;

                // User settings.
                options.User.AllowedUserNameCharacters =
                "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                options.User.RequireUniqueEmail = false;
            });
            services.AddScoped<UserManager<AppUser>>();
            services.AddScoped<SignInManager<AppUser>>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IAlbumRepository, AlbumRepository>();
        }
    }
}