using Data.ModelDb;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Data.Interface
{
    public interface ICRUD
    {
        ExceptionFull Add<T>(T entity);
        ExceptionFull Update<T>(T entity);
        ExceptionFull Delete<T>(T entity);
        Task<ExceptionFull> SaveChangesAsync();
        Task<List<T>> GetAllAsync<T>() where T : class;
        Task<List<T>> SearchAsync<T>(Expression<Func<T, bool>> where) where T : class;
        Task<T> SearchId<T>(Expression<Func<T, bool>> where) where T : class;
        void Erro(ExceptionFull exception);
    }
}
