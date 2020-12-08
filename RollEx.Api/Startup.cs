using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RollEx.Api.Models.Validators;
using RollEx.Models;
using RollEx.Services;

namespace RollEx.Api
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
            services.AddControllers()
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.WriteIndented = true;
                });

            services.AddMvcCore().
             SetCompatibilityVersion(CompatibilityVersion.Version_3_0).
             AddFluentValidation(x => { });
            services.AddTransient<IValidator<CharacterTrait>, CharacterTraitValidator>();
            services.AddTransient<IValidator<Game>, GameValidator>();
            services.AddTransient<IValidator<Hero>, HeroValidator>();
            services.AddTransient<IValidator<Progression>, ProgressionValidator>();
            services.AddTransient<IValidator<Vitals>, VitalsValidator>();

            services.AddScoped<INameGenerator, NameGenerator>();
            services.AddScoped<IHeroService, HeroService>();
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
