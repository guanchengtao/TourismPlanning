using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IRedisDAL;
using ServiceStack.Redis;

namespace RedisDAL
{
    public class RedisWriter : RedisConnection, IRedisWriter
    {
        private static RedisClient redisClient = null;

        public RedisWriter()
        {
            redisClient = GetRedisInstance();
        }
        #region 存储
        public void AddCache(string key, object value, DateTime expDate)
        {
            redisClient.Add(key, value, expDate);
        }
        public void AddCache(string key, object value)
        {
            redisClient.Add(key, value);
        }
        public int SetCache(string key, object value, DateTime extDate)
        {
            if (redisClient.Set(key, value, extDate))
                return 1;
            else
            {
                return 0;
            }
        }
        public void SetCache(string key, object value)
        {
            redisClient.Set(key, value);
        }
        public int AppendCache(string key, byte[] bt)
        {
            return redisClient.Append(key, bt);
        }
        public int AppendCache(string key, string value)
        {
            return redisClient.AppendToValue(key, value);
        }
        public void AddRangeToList(string key, List<string> list)
        {
            redisClient.AddRangeToList(key, list);
        }
        #endregion
        #region 删除

        public void DeleteCache(string key)
        {
            redisClient.Remove(key);
        }

        #endregion
        #region 获取
        public List<string> GetAllKeys()
        {
            return redisClient.GetAllKeys();
        }

        public async Task<object> GetCache(string key)
        {
            try
            {
                string res = await Task.Run(() => Encoding.ASCII.GetString(redisClient.Get(key)));
                string[] str = res.Split('\"');
                return str[1];
            }
            catch { }
            return null;
        }
        public object GetCache<T>(string key)
        {
            return redisClient.Get(key);
        }

        public string GetString(string key)
        {
            return redisClient.GetValue(key);
        }
        #endregion
        #region 判断

        public bool IsContainKey(string key)
        {
            return redisClient.ContainsKey(key);
        }

        public bool IsExist(string key)
        {
            return redisClient.Exists(key) > 0;
        }
        #endregion
        #region 自增自减
        public void Increment(string key, int count)
        {
            redisClient.IncrementValueBy(key, count);
        }

        public void Decrement(string key, int count)
        {
            redisClient.DecrementValueBy(key, count);
        }

        #endregion


        #region List
        public void EnqueueItemOnList(string queuelist, string value)
        {
            redisClient.EnqueueItemOnList(queuelist, value);
        }

        public string DequeueItemFromList(string queuelist)
        {
            return redisClient.DequeueItemFromList(queuelist);
        }

        public void PushItemToList(string stacklist, string value)
        {
            redisClient.PushItemToList(stacklist, value);
        }

        public string PopItemFromList(string stacklist)
        {
            return redisClient.PopItemFromList(stacklist);
        }

        #endregion

        #region Set
        public void AddItemToSet(string set, string value)
        {
            redisClient.AddItemToSet(set, value);
        }

        public void AddRangeToSet(string set, List<string> values)
        {
            redisClient.AddRangeToSet(set, values);
        }

        public bool SetIsContainsItem(string set, string value)
        {
            return redisClient.SetContainsItem(set, value);
        }

        public void AddItemToSortedSet(string sortset, string value, double score)
        {
            redisClient.AddItemToSortedSet(sortset, value, score);
        }

        public int GetSortedSetCount(string sortset)
        {
            return redisClient.GetSortedSetCount(sortset);
        }

        public Dictionary<string, double> GetRangeWithScoresFromSortedSet(string sortset, int fromRank, int toRank)
        {
            return (Dictionary<string, double>)redisClient.GetRangeWithScoresFromSortedSet(sortset, fromRank, toRank);
        }

        public Dictionary<string, double> GetRangeWithScoresFromSortedSetDesc(string sortset, int fromRank, int toRank)
        {
            return (Dictionary<string, double>)redisClient.GetRangeWithScoresFromSortedSetDesc(sortset, fromRank, toRank);
        }

        public void AOFSave()
        {
            redisClient.BgRewriteAof();
        }

        public void RDBSave()
        {
            redisClient.BgSave();
        }


        #endregion


    }
}
