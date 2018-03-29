using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using nutter.api.Models;

namespace nutter.api
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddDbContext<FoodItemContext>(opt => opt.UseSqlServer(Configuration.GetConnectionString("NutterContext")));
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseMvc();
        }
    }
}