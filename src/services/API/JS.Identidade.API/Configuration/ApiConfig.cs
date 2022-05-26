using JS.Identidade.API.Services;
using JS.Identidade.Domain.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NetDevPack.Security.JwtSigningCredentials.AspNetCore;

namespace JS.Identidade.API.Configuration
{
    public static class ApiConfig
    {
        public static IServiceCollection AddApiConfiguration(this IServiceCollection services)
        {
            services.AddControllers();

            services.AddScoped<AuthenticationService>();
            services.AddScoped<IAspNetUser, AspNetUser>();

            services.AddCors();

            //services.AddCors(options =>
            //{
            //    options.AddPolicy("Total",
            //        builder =>
            //            builder
            //            .AllowAnyOrigin()
            //            .AllowAnyMethod()
            //            .AllowAnyHeader());

            //    //options.AddPolicy("Production",
            //    //   builder =>
            //    //       builder
            //    //       .WithMethods("GET")
            //    //       .WithOrigins()
            //    //       .SetIsOriginAllowedToAllowWildcardSubdomains()
            //    //       .AllowAnyHeader());
            //});

            return services;
        }

        public static IApplicationBuilder UseApiConfiguration(this IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            //if (env.IsDevelopment())
            //{
            //    app.UseCors("Development");
            //    app.UseDeveloperExceptionPage();
            //}
            //else
            //{
            //    app.UseCors("Development"); // Usar apenas nas demos => Configuração Ideal: Production
            //    app.UseHsts();
            //}

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(x => x.AllowAnyHeader()
                              .AllowAnyMethod()
                              .AllowAnyOrigin());

            app.UseAuthConfiguration();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            
            app.UseJwksDiscovery();

            return app;
        }
    }
}