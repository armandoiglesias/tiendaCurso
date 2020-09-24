using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using TiendaService.Api.Book.Application;
using TiendaService.Api.Book.Models.Persistance;
using TiendaService.RabbitMQ.Bus.BusRabbit;
using TiendaService.RabbitMQ.Bus.Implementation;

namespace TiendaService.Api.Book
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

            services.AddTransient<IRabbitEventBus, RabbitEventBus>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
                .AddFluentValidation( cfg => {
                    cfg.RegisterValidatorsFromAssemblyContaining<Add>();
                });

            services.AddDbContext<BookStoreContext>(opt =>
            {
                opt.UseSqlServer(Configuration.GetConnectionString("Book_DB"));
            });

            services.AddMediatR( typeof( Add.Handler ).Assembly );

            services.AddAutoMapper(typeof(GetBooks.Execute));


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
