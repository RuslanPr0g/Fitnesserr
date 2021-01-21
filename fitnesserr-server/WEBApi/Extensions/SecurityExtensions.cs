using Microsoft.Extensions.DependencyInjection;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Builder;
using FluentValidation;
using WEBApi.PipelineBehaviors;

namespace WEBApi.Extensions
{
    public static class SecurityExtensions
    {
        // for the future jwt auth

        //public static IServiceCollection AddJWTokens(this IServiceCollection services, IConfiguration conf)
        //{
        //    services.AddSingleton<IJwtokenManagerFactory, JwtokenManagerFactory>();

        //    string key = conf.GetValue<string>("Key");
        //    services.AddAuthentication(x =>
        //    {
        //        x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        //        x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        //    })
        //    .AddJwtBearer(x =>
        //    {
        //        x.RequireHttpsMetadata = false;
        //        x.SaveToken = true;
        //        x.TokenValidationParameters = new TokenValidationParameters
        //        {
        //            ValidateIssuerSigningKey = true,
        //            IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(key)),
        //            ValidateIssuer = false,
        //            ValidateAudience = false
        //        };
        //    });

        //    services.AddSingleton<IJWTokenManager>(x => x.GetService<IJwtokenManagerFactory>().CreateTokenManager());

        //    return services;
        //}

        public static IServiceCollection AddValidators(this IServiceCollection services)
        {
            services.AddValidatorsFromAssembly(typeof(Startup).Assembly);
            services.AddTransient(typeof(ValidationBahavior<,>));
            return services;
        }
    }
}
