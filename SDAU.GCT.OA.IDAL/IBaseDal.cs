using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SDAU.GCT.OA.IDAL
{
    //封装公共方法
    public interface IBaseDal<T> where T : class, new()
    {
        //接口方法不需要public 默认的
        T Add(T t);
        bool DeleteSingle(int id);
        bool DeleteMultiple(List<int> ids);
        bool Update(T t);
        IQueryable<T> GetEntities(Expression<Func<T, bool>> WhereLambda);
        IQueryable<T> GetEntitiesByPage<S>(int pageSize, int pageIndex, out int total,
           Expression<Func<T, bool>> WhereLambda, Expression<Func<T, S>> OrderbyLambda, bool isAsc);
    }
}
