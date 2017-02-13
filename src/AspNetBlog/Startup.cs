using AspNetBlog.Models;
using AspNetBlog.Models.Identity;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.AspNet.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Framework.ConfigurationModel;
using Microsoft.AspNet.Http.Abstractions;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Data.Entity;


namespace AspNetBlog
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddScoped<BlogDataContext>();
            services.AddTransient<FormattingService>();

//            string blogDataConnectionString =
//                @"Data Source=localhost\\sqlexpress;Initial Catalog=AspNetBlog;User ID=sa;Password=1201";
//            string identityConnectionString = @"Data Source=localhost\\sqlexpress;Initial Catalog=AspNetBlog_Identity;User ID=sa;Password=1201";
//
//            services.AddEntityFramework()
//                .AddSqlServer()
//                .AddDbContext<BlogDataContext>(dbconfig => dbconfig.UseSqlServer(blogDataConnectionString))
//                .AddDbContext<IdentifyDataContext>(dbconfig => dbconfig.UseSqlServer(identityConnectionString));
//
//            services.AddEntityFramework()
//                .AddSqlServer()
//                .AddDbContext<Models.BlogDataContext>(dbConfig =>
//                    dbConfig.UseSqlServer(blogDataConnectionString))
//                .AddDbContext<Models.Identity.IdentifyDataContext>(dbConfig =>
//                    dbConfig.UseSqlServer(identityConnectionString));
//
//            services.AddIdentity<Models.Identity.ApplicationUser, IdentityRole>()
//                .AddEntityFrameworkStores<Models.Identity.IdentifyDataContext>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {
            var config=new Configuration();
            config.AddEnvironmentVariables();

//            app.UseIdentity();
            app.UseDeveloperExceptionPage();
            app.UseRuntimeInfoPage();
//            app.UseExceptionHandler("/home/error");

            app.UseMvc(routes => routes.MapRoute("Default", "{controller=Home}/{action=Index}/{id?}"));

            app.UseFileServer();
//            app.UseIISPlatformHandler();
//            app.Use(async (context, next) =>
//            {
//                if (context.Request.Path.Value.StartsWith("/hello"))
//                {
//                    await context.Response.WriteAsync("Hello World,  miss you!");
//                }
//                await next();
//            });
//
//            app.Run(async context => { await context.Response.WriteAsync("Hello World, viona chen I miss you!"); });
        }

        // Entry point for the application.
        public static void Main(string[] args) => WebApplication.Run<Startup>(args);
    }
}