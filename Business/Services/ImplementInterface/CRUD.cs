using Data;
using Data.Interface;
using Data.ModelDb;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Business.Services.ImplementInterface
{
    public class CRUD: ICRUD
    {
        protected readonly MadsanjContext _context;
        private readonly ExceptionFull _exception = new ExceptionFull();

        public CRUD(MadsanjContext context)
        {
            _context = context;
            _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public ExceptionFull Add<T>(T entity)
        {
            try
            {
                _context.Add(entity);
                _exception.Status = true;
            }
            catch (Exception ex)
            {
                _exception.Status = false;
                _exception.Mensagem = ex.Message;
            }
            return _exception;
        }

        public ExceptionFull Delete<T>(T entity)
        {
            try
            {
                _context.Remove(entity);
                _exception.Status = true;
            }
            catch (Exception ex)
            {
                _exception.Status = false;
                _exception.Mensagem = ex.Message;
            }
            return _exception;
        }

        public async Task<ExceptionFull> SaveChangesAsync()
        {
            try
            {
                if (await _context.SaveChangesAsync() < 0)
                    throw new Exception("SaveChanges retorno < 0");

                _exception.Status = true;

            }
            catch (Exception ex)
            {
                _exception.Status = false;
                _exception.Mensagem = ex.Message;
            }

            return _exception;
        }

        public ExceptionFull Update<T>(T entity)
        {
            try
            {
                _context.Update(entity);
                _exception.Status = true;
            }
            catch (Exception ex)
            {
                _exception.Status = false;
                _exception.Mensagem = ex.Message;
            }

            return _exception;
        }

        public async Task<List<T>> GetAllAsync<T>() where T : class =>
            await _context.Set<T>().ToListAsync();

        public async Task<List<T>> SearchAsync<T>(Expression<Func<T, bool>> where) where T : class =>
            await _context.Set<T>().Where(where).ToListAsync();

        public async Task<T> SearchId<T>(Expression<Func<T, bool>> where) where T : class =>
            await _context.Set<T>().Where(where).FirstOrDefaultAsync();

        public void Erro(ExceptionFull exception)
        {
           // _context.Database.ExecuteSqlCommand(exception);
        }
    }

}
