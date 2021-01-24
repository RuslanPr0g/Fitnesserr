using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using System;
using WEBApi.Repository;

namespace WEBApi.Extensions
{
    public static class DataAccessExtentions
    {
        public static IServiceCollection AddDapperDatabase(this IServiceCollection services)
        {
            //services.AddSingleton<ISQLDataAccess, SQLDataAccess>();
            //services.AddSingleton<IUserRepo, UserRepo>();

            //SqlMapper.AddTypeHandler(new PostgreGuidTypeHandler());
            //SqlMapper.RemoveTypeMap(typeof(Guid));
            //SqlMapper.RemoveTypeMap(typeof(Guid?));

            return services;
        }
    }
}
