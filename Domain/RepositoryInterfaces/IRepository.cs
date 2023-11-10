using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.RepositoryInterfaces
{
    public interface IRepository<T>
    {
        void Add(T obj);
        void Remove(T obj);
        void Update(T obj);
        IEnumerable<T> FindAll();
        T FindById(int id);        
    }
}
