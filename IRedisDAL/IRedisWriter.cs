using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IRedisDAL
{
    public partial interface IRedisWriter
    {
        #region 增
        void AddCache(string key, object value, DateTime expDate);
        void AddCache(string key, object value);
        int AppendCache(string key, byte[] bt);
        int AppendCache(string key, string value);
        void AddRangeToList(string key, List<string> list);
        int SetCache(string key, object value, DateTime extDate);
        void SetCache(string key, object value);
        #endregion

        #region 查
        Task<object> GetCache(string key);
        object GetCache<T>(string key);
        List<string> GetAllKeys();
        string GetString(string key);
        //byte[] GetHash(string hashId, byte[] by);
        //string GetType(string key);
        #endregion

        #region 删
        void DeleteCache(string key);
        #endregion

        #region 判断
        bool IsExist(string key);
        bool IsContainKey(string key);
        #endregion

        #region 持久化
        void AOFSave();
        void RDBSave();
        #endregion

        #region Hash
        //bool Exist<T>(string hashId, string key);
        //bool Set<T>(string hashId, string key, T t);
        //Task<int> Remove(string hashId, byte[] key);
        //bool Remove(string key);
        //T Get<T>(string hashId, string key);
        //List<T> GetAll<T>(string hashId);
        //void SetExpire(string key, DateTime datetime);
        //Task<int> HMSet(string HashId, byte[][] keys, byte[][] values);
        //Task<int> HSet(string HashId, byte[] key, byte[] value);
        //Task<string> HGet(string HashId, byte[] key);
        // Task<byte[][]> GetAllHKeys(string HashId);
        #endregion

        #region 自增和自减

        void Increment(string key, int count);
        void Decrement(string key, int count);
        #endregion

        #region List 队列

        void EnqueueItemOnList(string queuelist, string value);
        string DequeueItemFromList(string queuelist);


        #endregion
        #region  List 栈
        void PushItemToList(string stacklist, string value);
        string PopItemFromList(string stacklist);

        #endregion

        #region Set
        void AddItemToSet(string set, string value);
        void AddRangeToSet(string set, List<string> values);
        bool SetIsContainsItem(string set, string value);
        void AddItemToSortedSet(string sortset, string value, double score);
        int GetSortedSetCount(string sortset);
        Dictionary<string, double> GetRangeWithScoresFromSortedSet(string sortset, int fromRank, int toRank);
        Dictionary<string, double> GetRangeWithScoresFromSortedSetDesc(string sortset, int fromRank, int toRank);
        #endregion




    }
}
