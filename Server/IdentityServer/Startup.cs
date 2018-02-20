using DAL.EF;
using DAL.Interfaces;
using DAL.UnitOfWorks;
using IdentityServer.Helpers;
using IdentityServer4.Services;
using IdentityServer4.Validation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Data.SqlClient;

namespace IdentityServer
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
            if (Configuration["MyORM"] == "EF")
            {
                services.AddScoped<IUnitOfWork, EFUnitOfWork>();
            }
            else
            {
                services.AddScoped<IUnitOfWork, DapperUnitOfWork>(provider =>
                    new DapperUnitOfWork(new SqlConnection(Configuration.GetConnectionString("DefaultConnection"))));
            }
            services.AddTransient<IProfileService, UserProfileService>();
            services.AddTransient<IResourceOwnerPasswordValidator, UserResourceOwnerPasswordValidator>();

            services.AddDbContext<ClinicContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddMvc();

            // configure identity server with in-memory stores, keys, clients and scopes
            services.AddIdentityServer()
                .AddDeveloperSigningCredential()
                .AddInMemoryIdentityResources(Config.GetIdentityResources())
                .AddInMemoryApiResources(Config.GetApiResources())
                .AddInMemoryClients(Config.GetClients())
                .AddProfileService<UserProfileService>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseIdentityServer();
            
            app.UseMvc();
        }
    }
}
