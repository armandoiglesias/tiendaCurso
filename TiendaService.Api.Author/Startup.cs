using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using TiendaService.Api.Author.Application.Querys;
using TiendaService.Api.Author.Models.Persistance;
using TiendaService.Api.Author.RabbitHandler;
using TiendaService.Message.Email.SendGridLibrary.Interface;
using TiendaService.Message.Email.SendGridLibrary.Implementation;
using TiendaService.RabbitMQ.Bus.BusRabbit;
using TiendaService.RabbitMQ.Bus.EventQueue;
using TiendaService.RabbitMQ.Bus.Implementation;

namespace TiendaService.Api.Author
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
            services.AddSingleton<IRabbitEventBus, RabbitEventBus>(sp =>
           {
               var scopeFactory = sp.GetRequiredService<IServiceScopeFactory>();
               return new RabbitEventBus(sp.GetService<IMediator>(), scopeFactory);
           });

            services.AddSingleton<ISendGridSend, SendGridSend>();

            services.AddTransient<EmailEventHandler>();

            services.AddTransient<IEventHandler<EmailEventQueue>, EmailEventHandler>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
                .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<Models.Author>());

            services.AddDbContext<ContextAuthor>(options =>
           {
               options.UseNpgsql(Configuration.GetConnectionString("Author_DB"));
           });

            services.AddMediatR(typeof(Application.Nuevo.Handler).Assembly);

            services.AddAutoMapper(typeof(Query.Handler));
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            //ContextAuthor.Database.Migrate();

            //app.UseHttpsRedirection();
            app.UseMvc();

            var eventBus = app.ApplicationServices.GetRequiredService<IRabbitEventBus>();
            eventBus.Subscribe<EmailEventQueue, EmailEventHandler>();
        }
    }
}
