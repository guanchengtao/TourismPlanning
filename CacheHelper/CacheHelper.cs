using Spring.Context;
using Spring.Context.Support;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IRedisDAL;

namespace CacheHelper
{
    public class CacheHelper
    {
        public static IRedisWriter RedisWriter { get; set; }

        static CacheHelper()
        {
            IApplicationContext ctx = ContextRegistry.GetContext();
            RedisWriter = ctx.GetObject("CacheWriterRedis_") as IRedisWriter;
        }

        #region 存储

        public static void AddCache(string key, object value, DateTime exadate)
        {
            RedisWriter.AddCache(key, value, exadate);
        }
        public static void AddCache(string key, object value)
        {
            RedisWriter.AddCache(key, value);
        }

        public static int SetCache(string key, object value, DateTime extDate)
        {
            return RedisWriter.SetCache(key, value, extDate);
        }
        public static void SetCache(string key, object value)
        {
            RedisWriter.SetCache(key, value);
        }
        public static int AppendCache(string key, byte[] bt)
        {
            return RedisWriter.AppendCache(key, bt);
        }
        public static int AppendCache(string key, string value)
        {
            return RedisWriter.AppendCache(key, value);
        }
        public static void AddRangeToList(string key, List<string> list)
        {
            RedisWriter.AddRangeToList(key, list);
        }
        public static void AddRangeToSet(string key, List<string> item)
        {
            RedisWriter.AddRangeToSet(key, item);
        }
        #endregion

        #region 删除
        public static void DeleteCache(string key)
        {
            RedisWriter.DeleteCache(key);
        }

        #endregion

        #region 读取
        public static List<string> GetAllKeys()
        {
            return RedisWriter.GetAllKeys();
        }
        public static async Task<object> GetCache(string key)
        {
            return await RedisWriter.GetCache(key);
        }
        public static object GetCache<T>(string key)
        {
            return RedisWriter.GetCache(key);
        }
        public static string GetString(string key)
        {
            return RedisWriter.GetString(key);
        }
        #endregion

        #region 判断
        public static bool IsContainKey(string key)
        {
            return RedisWriter.IsContainKey(key);
        }

        public static bool IsExist(string key)
        {
            return RedisWriter.IsExist(key);
        }
        #endregion

        #region 自增和自减

        public static void Increment(string key, int count)
        {
            RedisWriter.Increment(key, count);
        }

        public static void Decrement(string key, int count)
        {
            RedisWriter.Decrement(key, count);
        }
        #endregion

        #region List
        public static void EnqueueItemOnList(string queuelist, string value)
        {
            RedisWriter.EnqueueItemOnList(queuelist, value);
        }

        public static string DequeueItemFromList(string queuelist)
        {
            return RedisWriter.DequeueItemFromList(queuelist);
        }

        public static void PushItemToList(string stacklist, string value)
        {
            RedisWriter.PushItemToList(stacklist, value);
        }

        public static string PopItemFromList(string stacklist)
        {
            return RedisWriter.PopItemFromList(stacklist);
        }

        #endregion


        #region Set
        public static void AddItemToSet(string set, string value)
        {
            RedisWriter.AddItemToSet(set, value);
        }


        public static bool SetIsContainsItem(string set, string value)
        {
            return RedisWriter.SetIsContainsItem(set, value);
        }

        public static void AddItemToSortedSet(string sortset, string value, double score)
        {
            RedisWriter.AddItemToSortedSet(sortset, value, score);
        }

        public static int GetSortedSetCount(string sortset)
        {
            return RedisWriter.GetSortedSetCount(sortset);
        }

        public static Dictionary<string, double> GetRangeWithScoresFromSortedSet(string sortset, int fromRank, int toRank)
        {
            return (Dictionary<string, double>)RedisWriter.GetRangeWithScoresFromSortedSet(sortset, fromRank, toRank);
        }

        public static Dictionary<string, double> GetRangeWithScoresFromSortedSetDesc(string sortset, int fromRank, int toRank)
        {
            return (Dictionary<string, double>)RedisWriter.GetRangeWithScoresFromSortedSetDesc(sortset, fromRank, toRank);
        }

        #endregion

        //appond only file   写进日志
        public static void AOFSave()
        {
            RedisWriter.AOFSave();
        }
        //rdb快照
        public static void RDBSave()
        {
            RedisWriter.RDBSave();
        }
    }
}
