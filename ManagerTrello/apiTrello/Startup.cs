using apiTrello.Helpers;
using apiTrello.Repository.Data;
using apiTrello.Repository.Interfaces;
using apiTrello.Repository.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Specialized;
using System.Text;

namespace apiTrello
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddDbContext<apiTrelloContext>(options =>
            {
                options.UseSqlServer(Configuration.GetSection("SqlServerConnections").Value);
            });
            services.AddSingleton<IQuadroRepository, QuadroRepository>();

            services.AddHttpClient("trello", c =>
            {
                c.BaseAddress = new Uri("https://api.trello.com/1/members/me/[parameters]")
                                        .AttachParameters(new NameValueCollection{
                                                                { "key", Configuration.GetSection("key").Value },
                                                                { "token",  Configuration.GetSection("token").Value } }
                                        );
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
        
    }
}
