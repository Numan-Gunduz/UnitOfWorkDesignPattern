using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitOfWorkDesignPattern.DataAccessLayer.Abstract;
using UnitOfWorkDesignPattern.DataAccessLayer.Concrete;

namespace UnitOfWorkDesignPattern.DataAccessLayer.Repositories
{
    //normalde bu sayfalarda sacechange kullanıyorduk unit of work oldıuğu için buraada olmuyor

    public class GenericRepository<T> : IGenericDal<T> where T : class
    {
        private readonly ApplicationDbContext _context;

        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Delete(T entity)
        {
            _context.Remove(entity);
        }

        public T GetByID(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public List<T> GetList()
        {
         return _context.Set<T>().ToList();
        }

        public void Insert(T entity)
        {
           _context.Add(entity);
        }

        public void MultiUpdate(List<T> entity)
        {
          _context.UpdateRange(entity);
        }

        public void Update(T entity)
        {
            _context.Update(entity);
        }
    }
}
