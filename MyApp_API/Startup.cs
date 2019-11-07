using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
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
using System.IdentityModel.Tokens.Jwt;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

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

            services.AddSignalR();
            services.AddHttpContextAccessor();

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
                        return Task.CompletedTask;
                    },
                    OnTokenValidated = context =>
                    {
                        Console.WriteLine("OnTokenValidated: " + context.SecurityToken);
                        return Task.CompletedTask;
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
                        return Task.CompletedTask;
                    }
                };
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseHttpsRedirection();
            #region ===== Swagger ======

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
            //loggerFactory.AddFile(Configuration.GetValue<string>("Logging:LogFilePath"));
            #region ===== Use Cors ======
            app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

            #endregion

            app.UseMvc();
        }

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
    }
}
