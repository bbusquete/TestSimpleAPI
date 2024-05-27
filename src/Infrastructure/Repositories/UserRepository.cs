using Infrastructure.Models;
using NPoco;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NPoco.SqlServer;

namespace Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IDbFactory _dbFactory;

        public UserRepository(IDbFactory dbFactory)
        {
            _dbFactory = dbFactory;
        }


        public void Add(User user)
        {
            using (var db = _dbFactory.GetConnection())
            {
                db.Insert<User>(user);
            }
        }

        public void Delete(int id)
        {
            using (var db = _dbFactory.GetConnection())
            {
                var user = db.SingleById<User>(id);
                user.IsActive = false;
                db.Update(user);
            }
        }

        public IList<User> GetAll()
        {
            IList<User> list;
            using (var db = _dbFactory.GetConnection())
            {
                //string query = "SELECT * FROM Investiments";
                list= db.Fetch<User>();
            }
            return list.ToList();
        }

        public User GetById(int id)
        {
            User user = null;
            using (var db = _dbFactory.GetConnection())
            {
                user =  db.SingleById<User>(id);
            }

            return user;
        }

        public void Update(int id, User user)
        {
            using (var db = _dbFactory.GetConnection())
            {
                user.Id = id;
                db.Update(user);
            }
        }
    }
}
