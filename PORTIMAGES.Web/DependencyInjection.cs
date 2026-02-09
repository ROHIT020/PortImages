using Microsoft.AspNetCore.Authentication.Cookies;

namespace PORTIMAGES.Web
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddWebLayer(this IServiceCollection services)
        {
            services.AddControllersWithViews().AddRazorRuntimeCompilation();
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                 .AddCookie(options =>
                 {
                     options.LoginPath = "/AuthEmployee/Login";
                     options.LogoutPath = "/AuthEmployee/Logout";
                     options.AccessDeniedPath = "/AuthEmployee/AccessDenied";
                     options.ExpireTimeSpan = TimeSpan.FromMinutes(10);
                     options.SlidingExpiration = true;
                 });           
            return services;
        }
    }
}
