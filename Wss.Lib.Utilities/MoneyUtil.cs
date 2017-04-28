using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using StackExchange.Redis;
using Websosanh.Core.Drivers.Redis;

namespace Wss.Lib.Utilities
{
    public class MoneyUtil
    {
        private readonly IDatabase _database;
        private DateTime _lastUpdate = new DateTime(1990, 10, 10);
        private Dictionary<string, int> _dicMoneyConfig = new Dictionary<string, int>();

        public MoneyUtil()
        {
            _database = RedisManager.GetRedisServer("redisMoneyConfig").GetDatabase(0);
        }

        public int GetMoneyRate(string money)
        {
            if ((DateTime.Now - _lastUpdate).TotalHours > 1 || !_dicMoneyConfig.ContainsKey(money))
            {
                _dicMoneyConfig=new Dictionary<string, int>();
                var x = _database.HashGetAll("MoneyConfig");
                foreach (var variable in x)
                {
                    _dicMoneyConfig.Add(variable.Key, Convert.ToInt32(variable.Value));
                }
                _lastUpdate = DateTime.Now;
            }

            if (_dicMoneyConfig.ContainsKey(money))
                return
                    _dicMoneyConfig[money];
            else return 1;
        }

    }
}
