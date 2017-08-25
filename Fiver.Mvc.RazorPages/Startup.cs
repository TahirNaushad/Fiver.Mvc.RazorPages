using Fiver.Mvc.RazorPages.OtherLayers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace Fiver.Mvc.RazorPages
{
    public class Startup
    {
        public void ConfigureServices(
            IServiceCollection services)
        {
            services.AddSingleton<IMovieService, MovieService>();
            services.AddMvc();
            //services.AddMvc()
            //        .AddRazorPagesOptions(options =>
            //        {
            //            options.RootDirectory = "/MyPages";
            //        });
        }

        public void Configure(
            IApplicationBuilder app, 
            IHostingEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseMvc();
        }
    }
}
