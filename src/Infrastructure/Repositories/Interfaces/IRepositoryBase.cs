using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public interface IRepositoryBase<T>
    {
        IList<T> GetAll();
        T GetById(int id);
        void Add(T item);
        void Update(int id, T item);
        void Delete(int id);
    }
}
