using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public interface IUserRepository : IRepositoryBase<User>
    {
        IList<User> GetAll();
        User GetById(int id);
        void Add(User user);
        void Update(int id, User user);
        void Delete(int id);
    }
}
