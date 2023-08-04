﻿using Microsoft.OpenApi.Models;

namespace VC.PorterGroup.TestePratico;

public static class InstalarSwagger
{
    public static IServiceCollection ConfigurarSwagger(this IServiceCollection services)
    {
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "VC.PorterGroup", Version = "v1" });
        });

        return services;
    }
}