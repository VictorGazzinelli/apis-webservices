
using GraphQLWebAPI.Infra;
using GraphiQl;
using GraphQL;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System;
using GraphQLWebAPI.Types;
using GraphQLWebAPI.Mutations;

namespace GraphQLWebAPI
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
            services.
                AddMvc(option => option.EnableEndpointRouting = false)
                .SetCompatibilityVersion(CompatibilityVersion.Version_3_0)
                .AddNewtonsoftJson(opt => opt.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);
            services.AddTransient<UsuarioRepositorio, UsuarioRepositorio>();
            services.AddScoped<BlogSchema>();
            services.AddScoped<BlogQuery>();
            services.AddScoped<BlogMutation>();
            services.AddScoped<UsuarioType>();
            services.AddScoped<UsuarioInputType>();
            services.AddDbContext<BlogContext>(opcoes => opcoes.UseInMemoryDatabase(databaseName: "Blog"));

        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseGraphiQl();
            app.UseMvc();
        }
    }
}
