using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SDAU.GCT.OA.IBLL
{
    public interface IBaseService<T> where T:class ,new()
    {
        T Add(T t);
        bool DeleteSingle(int id);
        bool DeleteMultiple(List<int> ids);
        bool Update(T t);
        IQueryable<T> GetEntities(Expression<Func<T, bool>> WhereLambda);
        IQueryable<T> GetEntitiesByPage<S>(int pageSize, int pageIndex, out int total,
           Expression<Func<T, bool>> WhereLambda, Expression<Func<T, S>> OrderbyLambda, bool isAsc);
    }
}
