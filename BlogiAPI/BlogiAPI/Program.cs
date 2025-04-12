using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using BlogiAPI.Chain;
using BlogiAPI.ServiceDefaults;
using Microsoft.OpenApi.Models;
using BlogiAPI.Client;
using BlogiAPI.Domain;
using BlogiAPI.Domain.Repositories.Base;

namespace BlogiAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            
            /*builder.WebHost.ConfigureKestrel(serverOptions =>
            {
                serverOptions.ListenAnyIP(5000); 
            });*/
            
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowReactApp", builder =>
                {
                    builder.WithOrigins("http://localhost:3000")
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
            });

         
            
            builder.Configuration.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            var connectionString = builder.Configuration["ConnectionStrings:DefaultConnection"] ?? throw new NullReferenceException("ConnectionString is null");

            BaseConstants.DbConnectionString = builder.Configuration["ConnectionStrings:DefaultConnection"] ?? throw new NullReferenceException("ConnectionString is null");

            //DI
            var services = builder.Services;
            services.RegisterOrchestrators();
            services.RegisterAllHandlers();
            services.RegisterAllRepositories();
            
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Blogi API", Version = "v1" });

                // Add security definition
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n" +
                                  "Enter your token only (without 'Bearer ' prefix) in the text input below.",
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer",
                    BearerFormat = "JWT"
                });
                

                // Add security requirement
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[] {}
                    }
                });
            });
            
            // Add authentication and authorization services
            services.AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = builder.Configuration["JwtConfig:Issuer"],
                        ValidAudience = builder.Configuration["JwtConfig:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JwtConfig:Key"] ?? throw new InvalidOperationException()))
                    };
                });
            
            
            // Add necessary services including your service defaults
            builder.AddServiceDefaults();
            builder.Services.AddControllers();

            // Configure OpenAPI / Swagger
            builder.Services.AddEndpointsApiExplorer(); 
            

            var app = builder.Build();

            // Enable middleware for Swagger/OpenAPI
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Blogi API V1");
                    c.RoutePrefix = string.Empty; // Serve the Swagger UI at the app's root
                });
            }
            else
            {
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Blogi API V1");
                    c.RoutePrefix = string.Empty; // Serve the Swagger UI at the app's root
                });
            }

            // Configure the HTTP request pipeline
            
            app.UseCors("AllowReactApp");
            
            
            app.UseHttpsRedirection();
            app.UseAuthentication(); 
            app.UseAuthorization();
            
            app.MapControllers();
            app.MapDefaultEndpoints();

            Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;

            app.Run();
        }
    }
}