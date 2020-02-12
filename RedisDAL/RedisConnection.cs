using ServiceStack.Redis;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedisDAL
{
    public  class RedisConnection
    {
        //单例模式
        private static RedisClient redisClientInstance = null;
        private static readonly object Locker = new object();
        //private RedisConnection() { }
       public static string appRedisConnection = ConfigurationManager.AppSettings["Rediscacheserver"];
        public static RedisClient GetRedisInstance()
        {
            //为了不至于每次调用GetRedisInstance方法都要加锁，减小了系统开销
            if (redisClientInstance == null)
            {
                lock(Locker)
                {
                    //防止创建多个对象，加双重锁
                    if(redisClientInstance == null)
                    {
                        //可连接多个服务器
                        string[] servers = appRedisConnection.Split(',');
                        foreach (string item in servers)
                        {
                            string[] hostandport = item.Split(':');
                            string host = hostandport[0];
                            int port = int.Parse(hostandport[1]);
                            redisClientInstance = new RedisClient(host, port);
                        }
                    }
                }
            }
            return redisClientInstance;
            
        }
    }
}
