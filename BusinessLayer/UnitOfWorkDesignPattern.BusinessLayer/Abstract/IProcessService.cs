using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitOfWorkDesignPattern.DataAccessLayer.Abstract;
using UnitOfWorkDesignPattern.EntityLayer.Concrete;


namespace UnitOfWorkDesignPattern.BusinessLayer.Abstract
{
    public interface IProcessService:IGenericService<Process>
    {
    }
}
