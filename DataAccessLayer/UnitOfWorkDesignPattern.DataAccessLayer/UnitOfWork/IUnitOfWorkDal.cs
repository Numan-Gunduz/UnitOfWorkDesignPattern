﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitOfWorkDesignPattern.DataAccessLayer.UnitOfWork
{
    public interface IUnitOfWorkDal
    {
        void Save();
    }
}
