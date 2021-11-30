using ApiRestful.core.EntidadesPersonalizadas;
using ApiRestful.core.Interfaces;
using ApiRestful.core.Services;
using ApiRestful.Infraestructura.Data;
using ApiRestful.Infraestructura.Filters;
using ApiRestful.Infraestructura.Interfaces;
using ApiRestful.Infraestructura.Repositorios;
using ApiRestful.Infraestructura.Services;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.IO;
using System.Reflection;

namespace ApiRestful.Api
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
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddControllers( options => options.Filters.Add<GlobalExceptionFilter>());
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ApiRestful.Api", Version = "v1" });
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });

            //dependencias
            services.Configure<PaginationOptions>(Configuration.GetSection("Pagination"));
            services.AddDbContext<ApiRestfulContext>(opciones =>
                opciones.UseSqlServer(Configuration.GetConnectionString("ApiRestful")));
            

            services.AddTransient<IPostService, PostService>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));

            services.AddSingleton<IUriPostServices>(provieder =>
            {
                var accessor = provieder.GetRequiredService<IHttpContextAccessor>();
                var request = accessor.HttpContext.Request;
                var absoluteUri = string.Concat(request.Scheme, "://", request.Host.ToUriComponent());
                return new UriPostServices(absoluteUri);
            });

            services.AddMvc().AddFluentValidation(option => option.RegisterValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ApiRestful.Api v1"));
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
