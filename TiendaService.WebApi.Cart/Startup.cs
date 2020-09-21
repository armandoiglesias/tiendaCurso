using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using TiendaService.WebApi.Cart.Application;
using TiendaService.WebApi.Cart.Models.Persistance;
using TiendaService.WebApi.Cart.RemoteInterface;
using TiendaService.WebApi.Cart.RemoteServices;

namespace TiendaService.WebApi.Cart
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
            services.AddScoped<IBookInterface, BookService>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddDbContext<CartContext>(optiosn =>
           {
               optiosn.UseMySql( Configuration.GetConnectionString("Cart_DB"));

           });

            services.AddMediatR( typeof(CartNew.Handler).Assembly );

            services.AddHttpClient("books", config =>
            {
                config.BaseAddress = new Uri(Configuration["Services:Book"]);
            });



        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
