using Authenticator_project.Data;
using Authenticator_project.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

namespace Authenticator_project.Extensions
{
    public static class IdentityServiceExtensions
    {
        public static IServiceCollection AddIdentityServices(this IServiceCollection services,
            IConfiguration config)
        {
            services.AddDbContext<DataContext>(options =>
                 options.UseSqlite(
                     config.GetConnectionString("DefaultConnection")));

            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder =>
                builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());
            });


            services.AddIdentityCore<AppUser>(opt =>
            {
                opt.Password.RequireNonAlphanumeric = false;
            })
                   .AddRoles<AppRole>()
                   .AddSignInManager<SignInManager<AppUser>>()
                   .AddEntityFrameworkStores<DataContext>();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["TokenKey"])),
                        ValidateIssuer = false,
                        ValidateAudience = false,
                    };
                });


            services.AddAuthorization(opt =>
            {
                opt.AddPolicy("AdminAndBackOffice", policy => policy.RequireRole("Admin", "BackOffice"));
            });


            services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "CSharp_Challenge",
                    Version = "v1",
                    Description = "Authenticator API by Donkennie",
                    TermsOfService = new Uri("https://example.com/terms"),
                    Contact = new OpenApiContact
                    {
                        Name = "Ajeigbe Kehinde",
                        Email = "ajeigbekehinde160@gmail.com",
                        Url = new Uri("https://donkennie.me/"),
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Authenticator API LICX",
                        Url = new Uri("https://example.com/license"),
                    }
                });

                s.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Place to add JWT with Bearer",
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });
                s.AddSecurityRequirement(new OpenApiSecurityRequirement()
             {
                 {
                 new OpenApiSecurityScheme
                 {
                     Reference = new OpenApiReference
                     {
                     Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                    },
                    Name = "Bearer",

                },

                 new List<string>()

                    }
                 });

            });



            return services;
        }

    }

}
