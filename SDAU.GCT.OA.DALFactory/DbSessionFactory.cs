using SDAU.GCT.OA.IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace SDAU.GCT.OA.DALFactory
{
    public class DbSessionFactory
    {
        /// <summary>
        /// 一次请求共用一个DbSession实例
        /// </summary>
        /// <returns></returns>
        public static IDbSession GetCurrentSession()
        {
            if (!(CallContext.GetData("DbSession") is IDbSession db))
            {
                db = new DbSession();
                CallContext.SetData("DbSession", db);
            }
            return db;
        }
    }
}
