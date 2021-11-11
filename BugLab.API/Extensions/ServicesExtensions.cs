using BugLab.Business.Extensions;
using BugLab.Business.Options;
using BugLab.Data;
using BugLab.Data.Extensions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BugLab.API.Extensions
{
    public static class ServicesExtensions
    {
        public static void AddApiServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddBusinessServices();
            services.AddDataServices(config);
            services.AddSwagger();
            services.AddAuth(config);
        }

        public static void AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "BugLab.API", Version = "v1" });

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT bearer authorization header",
                    Scheme = "Bearer",
                    Type = SecuritySchemeType.Http
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                   {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Id = "Bearer",
                            Type = ReferenceType.SecurityScheme
                        }
                    }, new List<string>() }
                });
            });
        }

        private static void AddAuth(this IServiceCollection services, IConfiguration config)
        {
            services.AddIdentity<IdentityUser, IdentityRole>(options =>
            {
                options.User.RequireUniqueEmail = true;
            }).AddEntityFrameworkStores<AppDbContext>();

            var jwtOptions = config.GetSection(nameof(JwtOptions)).Get<JwtOptions>();
            services.Configure<JwtOptions>(config.GetSection(nameof(JwtOptions)));

            services.AddCors(opt => opt.AddDefaultPolicy(builder => builder.WithOrigins(jwtOptions.ValidAudience).AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin()));

            services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(opt =>
            {
                opt.TokenValidationParameters = new TokenValidationParameters
                {
                    // server
                    ValidateIssuer = true,
                    ValidIssuer = jwtOptions.ValidIssuer,
                    // client
                    ValidateAudience = true,
                    ValidAudience = jwtOptions.ValidAudience,
                    // has not expired
                    ValidateLifetime = true,
                    RequireExpirationTime = true,
                    // server's key
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOptions.TokenKey)),
                };
            });
        }
    }
}
