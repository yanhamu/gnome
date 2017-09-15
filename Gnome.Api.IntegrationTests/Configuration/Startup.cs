﻿using Autofac;
using Gnome.Api.Filters;
using Gnome.Database;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Gnome.Api.IntegrationTests.Configuration
{
    public class Startup
    {
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(options =>
            {
                options.Filters.Add(new UserFilter());
            });

            services.AddCors();
            var container = DiConfiguration.CreateContainer(services);
            return container.Resolve<IServiceProvider>();
        }

        public void Configure(IApplicationBuilder app, Initializer initializer)
        {
            app.UseCors(builder =>
            {
                builder.AllowAnyOrigin();
                builder.AllowAnyHeader();
                builder.AllowAnyMethod();
            });

            if (initializer.HasAllTables() == false)
                initializer.DropAndCreate();
            app.UseMiddleware<IdentityMiddleware>();
            app.UseMvc();
        }
    }
}