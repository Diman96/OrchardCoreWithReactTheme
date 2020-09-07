using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace React
{
    public class Startup : StartupBase
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public override void ConfigureServices(IServiceCollection services)
        {

            

            // In production, the React files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/build";
            });
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public override void Configure(IApplicationBuilder app)
        {

           

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
            });

            /* app.MapWhen(x => !(x.Request.Path.Value.ToLower().StartsWith("/admin") 
             || x.Request.Path.Value.ToLower().StartsWith("/api")), builder =>*/
            app.Map("/app", spaApp =>
            {
                app.UseSpa(spa =>
                {
                    spa.Options.SourcePath = "../React/ClientApp";
                   

                    //if (env.IsDevelopment())

                    //spa.UseReactDevelopmentServer(npmScript: "start");

                    spa.UseReactDevelopmentServer(npmScript: "start --base-href=/app/ --serve-path=/");

                });
            });
            app.UseSpaStaticFiles();



        }

       
    }
}
