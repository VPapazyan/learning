using Entity_CodeFirst.DAL;
using Entity_CodeFirst.DAL.Interfaces;
using Entity_CodeFirst.DAL.Repositories;
using Entity_CodeFirst.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace Entity_CodeFirst
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
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Entity_CodeFirst", Version = "v1" });
            });

            services.AddDbContext<AppDbContext>(options => options
                                            .UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddTransient(typeof(ICustomerRepository), typeof(CustomerRepository));
            services.AddTransient(typeof(IOrderRepository), typeof(OrderRepository));
            services.AddTransient(typeof(IUnitOfWork), typeof(UnitOfWork));

            //services.AddTransient<ICustomerRepository, CustomerRepository>();
            //services.AddTransient<IOrderRepository, OrderRepository>();
            //services.AddTransient<IUnitOfWork, UnitOfWork>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Entity_CodeFirst v1"));
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
