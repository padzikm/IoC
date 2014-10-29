using System.Collections.Generic;
using System.Linq;
using Domain;
using StackExchange.Redis;

namespace Database
{
    public class LogRepository : ILogRepository
    {
        private static string key = "logs";

        public IEnumerable<string> GetAll()
        {
            using(var redis = ConnectionMultiplexer.Connect("localhost"))
            {
                IDatabase db = redis.GetDatabase();
                var list = db.ListRange(key);

                return list.Select(p => p.ToString());
            }
        }

        public void Save(string log)
        {
            using (var redis = ConnectionMultiplexer.Connect("localhost"))
            {
                IDatabase db = redis.GetDatabase();
                db.ListLeftPush(key, log);
            };
        }
    }
}
