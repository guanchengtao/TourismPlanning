
using SDAU.GCT.OA.IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SDAU.GCT.OA.BLL
{
    public abstract class BaseService<T> where T : class, new()
    {
        /// <summary>
        /// 父类要逼迫子类 在调用父类方法之前 给父类的一个属性赋值
        /// 
        /// </summary>
        public IBaseDal<T> CurrentDal { get; set; }

        //DbSession拥有所有dal的实例
        public IDbSession DbSession { get; set; }

        //子类重写 给父类的一个属性赋值
        public abstract void GetCurrentDal();


        public T Add(T t)
        {
            CurrentDal.Add(t);
            DbSession.Savechanges();
            return t;
        }
        
       public bool DeleteSingle(int id)
        {
            CurrentDal.DeleteSingle(id);
            return DbSession.Savechanges() > 0;
        }
       public bool DeleteMultiple(List<int> ids)
        {
            CurrentDal.DeleteMultiple(ids);
            return DbSession.Savechanges() > 0;
        }
       public bool Update(T t)
        {
            CurrentDal.Update(t);
          return  DbSession.Savechanges()>0;
        }
       public IQueryable<T> GetEntities(Expression<Func<T, bool>> WhereLambda)
        {
            return CurrentDal.GetEntities(WhereLambda);
        }
        public IQueryable<T> GetEntitiesByPage<S>(int pageSize, int pageIndex, out int total,
           Expression<Func<T, bool>> WhereLambda, Expression<Func<T, S>> OrderbyLambda, bool isAsc)
        {
            return CurrentDal.GetEntitiesByPage(pageSize, pageIndex, out total, WhereLambda, OrderbyLambda, isAsc);
        }

    }
}
