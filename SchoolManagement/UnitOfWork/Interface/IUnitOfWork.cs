using Data.Repositiory.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.UnitOfWork.Interface
{
    public interface IUnitOfWork
    {
        IGenericRepositiory<T> GenericRepositiory<T>() where T : class;

        void save();
    }
}
