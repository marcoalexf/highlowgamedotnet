using HighLowGame.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace HighLowGame.API.Extensions
{
    public static class DatabaseEx
    {
        public static IServiceCollection AddSQLite(this IServiceCollection collection, ConfigurationManager configuration)
        {
            var connection = configuration["ConnectionSqlite:SqliteConnectionString"];
            collection.AddDbContext<PlayerContext>(options =>
                options.UseSqlite(connection)
            );
            return collection;
        }
    }
}
