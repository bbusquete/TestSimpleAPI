using Domain.Entities;
using Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using Infrastructure.Models;

namespace Application.Behaviors
{
    public class UserService
    {
        private IUserRepository _repository;

        public UserService(IUserRepository portifolioRepository)
        {
            _repository = portifolioRepository;
        }
        public bool AddUser(Domain.Entities.User User) 
        {
            bool result = true;
            try
            {
                _repository.Add(ConvertToInfraModel(User));
            }
            catch (Exception)
            {
                throw;
                result = false;
            }
             
            return result;
        }

        public List<Domain.Entities.User> ListAllUsers()
        {
            var listDomain = new List<Domain.Entities.User>();

            try
            {
                var list = _repository.GetAll();
                
                foreach (var item in list)
                {
                    listDomain.Add(ConvertToModel(item));
                }
            }
            catch (Exception)
            {
                throw;
            }
            
            return listDomain;
        }


        public Domain.Entities.User GetUser(int id)
        {
            var user = new Domain.Entities.User();

            try
            {
                user = ConvertToModel(_repository.GetById(id));
            }
            catch (Exception ex)
            {
                throw;
            }
            
            return user; 
        }


        public bool UpdateUser(int id, Domain.Entities.User User)
        {
            bool result = true;
            try
            {
                _repository.Update(id, ConvertToInfraModel(User));
            }
            catch (Exception)
            {
                throw;
                result = false;
            }

            return result;
        }

      
        public void DeleteUser(int id)
        {
            _repository.Delete(id);
        }


        public Infrastructure.Models.User ConvertToInfraModel(Domain.Entities.User i)
        {
            return new Infrastructure.Models.User()
            {
               Name = i.Name,
               Email = i.Email,
               Password = i.Password

            };
        }

        public Domain.Entities.User ConvertToModel(Infrastructure.Models.User i)
        {
            return new Domain.Entities.User()
            {
                Name = i.Name,
                Email = i.Email,
                Password = i.Password
            };
        }

    }
}
