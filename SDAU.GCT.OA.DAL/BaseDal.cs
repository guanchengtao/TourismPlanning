
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SDAU.GCT.OA.DAL
{
    //约束T必须是一个类，而且默认有构造函数
   public class BaseDal<T> where T:class,new()
    {
        public DbContext Context {
            get
            {
                //上下文实例工厂
                return DbContextFactory.GetCurrentContext();
            }
        }
        public T Add(T t)
        {
            Context.Set<T>().Add(t);
            return t;
        }
        public bool DeleteSingle(int id)
        {
            var entity = Context.Set<T>().Find(id);
            Context.Entry(entity).Property("DelFlag").CurrentValue = 0;
            Context.Entry(entity).Property("DelFlag").IsModified = true;
            return true;
        }
        public bool DeleteMultiple(List<int> ids)
        {
            foreach (int  id in ids)
            {
                var entity = Context.Set<T>().Find(id);
                Context.Entry(entity).Property("DelFlag").CurrentValue =0;
                Context.Entry(entity).Property("DelFlag").IsModified = true;
            }         
            return true;
        }
        public bool Update(T t)
        {
            Context.Entry(t).State = EntityState.Modified;
            return true;
        }

        public IQueryable<T> GetEntities(Expression<Func<T,bool>> WhereLambda)
        {
            return Context.Set<T>().Where(WhereLambda).AsQueryable();
        }

        public IQueryable<T> GetEntitiesByPage<S>(int pageSize, int pageIndex, out int total,
          Expression<Func<T, bool>> WhereLambda, Expression<Func<T, S>> OrderbyLambda, bool isAsc)
        {
            total = Context.Set<T>().Where(WhereLambda).Count();
            IQueryable<T> temp =null;
            //升序
            if (isAsc)
            {
                 temp= Context.Set<T>().Where(WhereLambda)
                    .OrderBy(OrderbyLambda)
                    .Skip(pageSize * (pageIndex - 1))
                    .Take(pageSize).AsQueryable();
            }
            else
            {
                    temp = Context.Set<T>().Where(WhereLambda)
                       .OrderByDescending(OrderbyLambda)
                       .Skip(pageSize * (pageIndex - 1))
                       .Take(pageSize).AsQueryable();

            }
            return temp;
        }
    }
}
