using HowMuchItCost.API.Filters;
using HowMuchItCost.Library.Interfaces;
using HowMuchItCost.Library.Services;
using HowMuchItCost.Library.Services.Extractor;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace HowMuchItCost
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
            services.Configure<RequestLocalizationOptions>(options =>
            {
                options.DefaultRequestCulture = new Microsoft.AspNetCore.Localization.RequestCulture("en-US");
                options.SupportedCultures = new List<CultureInfo> { new CultureInfo("en-US") };
                options.RequestCultureProviders.Clear();
            });

            services.AddScoped<ICurrencyService, CurrencyService>();
            services.AddScoped<DogecoinService>();
            services.AddScoped<BitcoinService>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "HowMuchItCost",
                    Description = "A simple API to query currency prices",
                    Version = "v1"
                });
            });

            services.AddDistributedRedisCache(options =>
            {
                options.Configuration = Configuration.GetConnectionString("RedisConnection");
                options.InstanceName = "HowMuchItCostDatabase";
            });

            int cacheDuration = 5;

#if DEBUG
            cacheDuration = 0;
#endif

            services.AddControllers(options =>
            {
                options.Filters.Add(new ApiExceptionFilter());

                options.CacheProfiles.Add("Default", new CacheProfile()
                {
                    Duration = (int)TimeSpan.FromMinutes(cacheDuration).TotalSeconds,
                    Location = ResponseCacheLocation.Any,
                    NoStore = false
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRequestLocalization();

            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "HowMuchItCost v1"));

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
