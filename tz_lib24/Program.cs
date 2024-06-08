using Microsoft.EntityFrameworkCore;

namespace tz_lib24
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<libContext>(options =>
              options.UseSqlServer(builder.Configuration.GetConnectionString("libContext")));

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.MapControllerRoute(
    name: "books",
    pattern: "Books/{action=Index}/{id?}",
    defaults: new { controller = "Books", action = "Index" });

            app.MapControllerRoute(
                name: "returned",
                pattern: "ReturnedBooks/{action=Index}/{id?}",
                defaults: new { controller = "ReturnedBooks", action = "Index" });

            app.Run();
        }
    }
}