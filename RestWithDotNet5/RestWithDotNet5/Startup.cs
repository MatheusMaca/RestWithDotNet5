using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using RestWithDotNet5.Busines.Implementations;
using RestWithDotNet5.Model.Context;
using RestWithDotNet5.Repository.Implementations;

namespace RestWithDotNet5
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            var connection = Configuration["MySQLConnection:MySQLConnectionString"];
            
            //Versioning API -> Isto deve ser feito quando uma api estiver sendo usada e precisa ser alterada para outros consumidores  
            services.AddApiVersioning();

            services.AddDbContext<MySqlContext>(options => options.UseMySql(connection));
            
            //Injeção de dependencia
            services.AddScoped<IPersonBusines, PersonBusines>();
            services.AddScoped<IPersonRepository, PersonRepostory>();
            
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Documentação Swagger API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "RestWithDotNet5 v1"));
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
