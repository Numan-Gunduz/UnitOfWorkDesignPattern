using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitOfWorkDesignPattern.DataAccessLayer.Concrete;

namespace UnitOfWorkDesignPattern.DataAccessLayer.UnitOfWork
{
    public class UntiOfWorkDal : IUnitOfWorkDal
    {
        private readonly ApplicationDbContext _context;

        public UntiOfWorkDal(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
