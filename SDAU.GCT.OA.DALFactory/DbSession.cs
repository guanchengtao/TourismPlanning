using SDAU.GCT.OA.DAL;
using SDAU.GCT.OA.IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDAU.GCT.OA.DALFactory
{
    /// <summary>
    /// 拥有所以dal的实例，是整个数据库访问层的入口
    /// 是整个数据库访问层和数据库之间一次回话的代表
    /// </summary>
    public partial class DbSession:IDbSession
    {
        public int Savechanges()
        {
            //GetCurrentContext返回一个上下文
            return DbContextFactory.GetCurrentContext().SaveChanges();
        }
        public async Task<int> SaveChangesAsync()
        {
            //GetCurrentContext返回一个上下文
            return await DbContextFactory.GetCurrentContext().SaveChangesAsync();

        }
    }
}
