using MPZT.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPZT.Core.Repositories
{
    public interface IDataRepository<T> where T : EntityBase
    {
        T Get(int id);
        IList<T> GetAll();
        int InsertOrUpdate(T item);
        void Remove(int id);
    }
}
