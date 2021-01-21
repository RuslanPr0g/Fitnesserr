using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using System;

namespace WEBApi.Extensions
{
    public static class DataAccessExtentions
    {
        // for the future dapper db

        //public static IServiceCollection AddDapperDatabase(this IServiceCollection services)
        //{
        //    services.AddSingleton<ISQLDataAccess, SQLDataAccess>();
        //    services.AddSingleton<IUserReadRepo, UserReadRepo>();

        //    SqlMapper.AddTypeHandler(new PostgreGuidTypeHandler());
        //    SqlMapper.RemoveTypeMap(typeof(Guid));
        //    SqlMapper.RemoveTypeMap(typeof(Guid?));

        //    return services;
        //}
    }
}
