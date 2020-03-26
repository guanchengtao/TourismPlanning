using SDAU.GCT.OA.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace SDAU.GCT.OA.DAL
{
    public  class DbContextFactory
    {
       
        public static DbContext GetCurrentContext()
        {
            //一次请求共用一个实例
            if (!(CallContext.GetData("DbContext") is DbContext db))
            {
                //上下文也可以任意切换
                db = new Model1Container1();
                CallContext.SetData("DbContext", db);
            }
            return db;
        }
    }
}
