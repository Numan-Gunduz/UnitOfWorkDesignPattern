using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using UnitOfWorkDesignPattern.BusinessLayer.Abstract;
using UnitOfWorkDesignPattern.DataAccessLayer.Abstract;
using UnitOfWorkDesignPattern.DataAccessLayer.UnitOfWork;
using UnitOfWorkDesignPattern.EntityLayer.Concrete;

namespace UnitOfWorkDesignPattern.BusinessLayer.Concrete
{
    public class CustomerManager : ICustomerService
    {
        private readonly ICustomerDal _customerDal;
      private readonly IUnitOfWorkDal _unitOfWorkDal;

        public CustomerManager(ICustomerDal customerDal, IUnitOfWorkDal unitOfWorkDal)
        {
            _customerDal = customerDal;
            _unitOfWorkDal = unitOfWorkDal;
        }

        public void TDelete(Customer entity)
        {
            _customerDal.Delete(entity);
            _unitOfWorkDal.Save();
        }

        public Customer TGetByID(int id)
        {
            return _customerDal.GetByID(id);

        }

        public List<Customer> TGetList()
        {
           return _customerDal.GetList();
        }

        public void TInsert(Customer entity)
        {
           _customerDal.Insert(entity);
            _unitOfWorkDal.Save();
        }

        public void TMultiUpdate(List<Customer> entity)
        {
           _customerDal.MultiUpdate(entity);
            _unitOfWorkDal.Save();
        }

        public void TUpdate(Customer entity)
        {
           _customerDal.Update(entity);
            _unitOfWorkDal.Save();
        }
    }
}
