using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using MyApp.Core.Configs;
using MyApp.Core.Data.Entity;
using MyApp_API.Extentions;
using NJsonSchema;
using NSwag;
using NSwag.AspNetCore;
using NSwag.SwaggerGeneration.Processors.Security;
using System;
using System.Security.Cryptography;

namespace MyApp_API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            AppSettings.Configs = Configuration;
            AppSettings.Instance = configuration.GetSection("AppSettings").Get<AppSettings>();
            StaticConfig = configuration;
        }
        public static IConfiguration StaticConfig { get; private set; }
        public IConfiguration Configuration { get; }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            #region ===== Cors ========

            services.AddCors();

            #endregion

            #region ===== Dependency Injection ========

            services.AddDI();

            #endregion

            #region ===== Add our DbContext ========

            services.AddDbContext<DataContext>();

            #endregion

            #region  ===== Add MVC ========

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            #endregion

            #region ===== Add Swagger ======

            services.AddSwagger();

            #endregion

            #region ====== Add SignalR ======

            services.AddSignalR();

            #endregion

            #region ====== Add SignalR ======

            services.AddHttpContextAccessor();

            #endregion

            #region ====== Add Authentication ======

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = SigningKey(AppSettings.Configs.GetValue<string>("JwtSettings:RsaModulus"), AppSettings.Configs.GetValue<string>("JwtSettings:RsaExponent")),
                    ValidateIssuer = true,
                    ValidateAudience = false,
                    ValidIssuer = AppSettings.Configs.GetValue<string>("JwtSettings:Issuer"),
                    ValidateLifetime = true,

                                //ValidAudience = false
                            };

                x.Events = new JwtBearerEvents
                {
                    OnAuthenticationFailed = context =>
                    {
                        Console.WriteLine("OnAuthenticationFailed: " + context.Exception.Message);
                        return System.Threading.Tasks.Task.CompletedTask;
                    },
                    OnTokenValidated = context =>
                    {
                        Console.WriteLine("OnTokenValidated: " + context.SecurityToken);
                        return System.Threading.Tasks.Task.CompletedTask;
                    },
                    OnMessageReceived = context =>
                    {
                        var accessToken = context.Request.Query["access_token"];

                                    // If the request is for our hub...
                                    var path = context.HttpContext.Request.Path;
                        if (path.StartsWithSegments("/centerHub"))
                        {
                                        // Read the token out of the query string
                                        context.Token = accessToken;
                        }
                        return System.Threading.Tasks.Task.CompletedTask;
                    }
                };
            });

            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.UseHttpsRedirection();

            #region ===== Use Authentication ======

            app.UseAuthentication();

            #endregion

            #region ===== Use Swagger ======

            app.UseSwaggerUi3WithApiExplorer(settings =>
            {
                settings.GeneratorSettings.DefaultPropertyNameHandling =
                    PropertyNameHandling.CamelCase;

                settings.GeneratorSettings.Title = "VAS API";

                settings.GeneratorSettings.OperationProcessors.Add(new OperationSecurityScopeProcessor("Bearer"));

                settings.GeneratorSettings.DocumentProcessors.Add(new SecurityDefinitionAppender("Bearer",
                    new SwaggerSecurityScheme
                    {
                        Type = SwaggerSecuritySchemeType.ApiKey,
                        Name = "Authorization",
                        Description = "Copy 'Bearer ' + valid JWT token into field",
                        In = SwaggerSecurityApiKeyLocation.Header
                    }));
            });

            #endregion

            #region ===== Use Cors ======
            app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

            #endregion

            app.UseMvc();
        }

        #region ====== Create RSA Security ======

        private static RsaSecurityKey SigningKey(string key, string expo)
        {
            var rrr = RSA.Create();

            rrr.ImportParameters(
                new RSAParameters()
                {
                    Modulus = Base64UrlEncoder.DecodeBytes(key),
                    Exponent = Base64UrlEncoder.DecodeBytes(expo)
                }
            );

            return new RsaSecurityKey(rrr);
        }

        #endregion
    }
}
