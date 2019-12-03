using Microsoft.Extensions.Configuration;
using StackExchange.Redis;
using System;

namespace MyApp.Core.Configs
{
    public class CacheRedisSetting
    {
        public static Lazy<ConnectionMultiplexer> LazyConnection = new Lazy<ConnectionMultiplexer>(() =>
        {
            string connectionString = AppSettings.Configs.GetValue<string>("RedisConnectionString");
            return ConnectionMultiplexer.Connect(connectionString);
        });

        public static ConnectionMultiplexer ConnectionRedis
        {
            get
            {
                return LazyConnection.Value;
            }
        }

        public string setData()
        {
            IDatabase database = LazyConnection.Value.GetDatabase();
            database.StringSet("test", "mailinh");
            return database.StringGet("test");
        }
        public string getData()
        {
            IDatabase database = LazyConnection.Value.GetDatabase();
            return database.StringGet("test");

        }
    }

}
