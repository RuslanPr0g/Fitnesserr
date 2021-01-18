using System;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEBApi.Context;
using WEBApi.Repository;
using Newtonsoft.Json.Serialization;

namespace WEBApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "WEBApi", Version = "v1" });
            });
            
            services.AddDbContext<TrainingContext>(opt =>
                opt.UseSqlServer(Configuration.GetConnectionString("StandardSQLServer"),
                        options => options.MigrationsAssembly(nameof(WEBApi))));

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddControllers().AddNewtonsoftJson(s => {
                s.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            });

            services.AddScoped<IUserRepo, UserRepo>();
            services.AddScoped<ITrainingProgramRepo, TrainingProgramRepo>();
            services.AddScoped<ITrainingDoneRepo, TrainingDoneRepo>();
            services.AddScoped<ITrainingRepo, TrainingRepo>();
            services.AddScoped<IExerciseRepo, ExerciseRepo>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WEBApi v1"));
            }

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
