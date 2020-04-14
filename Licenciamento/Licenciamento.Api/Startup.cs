using AutoMapper;
using Licenciamento.domain.Identity;
using Licenciamento.repository.Data;
using Licenciamento.repository.Interfaces;
using Licenciamento.repository.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Text;

namespace Licenciamento.Api
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
            services
                .AddDbContext<LicenciamentoContext>
                (
                    options => options.UseSqlServer(Configuration.GetConnectionString("LocalSqlConnection"))
                );
                //.AddDbContext<LicenciamentoContext>(options =>
                //        options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection"))
                //        );

 //Tratamento para a senha
            IdentityBuilder builder = services.AddIdentityCore<User>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 4;
                
                //Definindo o máximo de tentativas que pode errar a senha
                options.Lockout.MaxFailedAccessAttempts = 5;

                //Definição de tempo de bloqueio padrão da senha
                options.Lockout.DefaultLockoutTimeSpan = new TimeSpan(0,5,0);
            });
            //Mapeamento de classes para as regras de autorização
            builder = new IdentityBuilder(builder.UserType,typeof(Role), builder.Services);
            builder.AddEntityFrameworkStores<LicenciamentoContext>();
            builder.AddRoleValidator<RoleValidator<Role>>();
            builder.AddRoleManager<RoleManager<Role>>();
            builder.AddSignInManager<SignInManager<User>>();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                    .AddJwtBearer(options =>
                    {
                        options.TokenValidationParameters = new TokenValidationParameters{
                            ValidateIssuerSigningKey = true,
                            IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII
                                                .GetBytes(Configuration.GetSection("AppSettings:Token").Value)),
                            ValidateIssuer = false,
                            ValidateAudience  = false
                        };
                    }
            );

            services.AddMvc(options =>
            {
                //Toda requisição via Controller passa a ser tratada por esta política de acesso
                var policy = new AuthorizationPolicyBuilder()
                                    .RequireAuthenticatedUser()
                                    .Build();
                //Filtro aplicado para autorizar de acordo com a politica de segurança
                options.Filters.Add(new AuthorizeFilter(policy));
            })
            .SetCompatibilityVersion(CompatibilityVersion.Version_2_2)

            //Passa a ignorar os retornos com loop da api
            //.AddJsonOptions(opt => opt.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            .AddJsonOptions(opt => { opt.JsonSerializerOptions.PropertyNamingPolicy = null; opt.JsonSerializerOptions.DictionaryKeyPolicy = null; });

            //Injeção do repository no services
            services.AddScoped<IMachineRepository, MachineRepository>();

            //Adicionando o automapper
            services.AddAutoMapper(typeof(Startup));
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

           // app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(x => x.AllowAnyOrigin()
                            .AllowAnyHeader()
                            .AllowAnyMethod()

                        );

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
