using DbModels.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Productify.Repo.IRepository;
using Productify.Service.CustomException;
using Productify.Service.ICustomServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Productify.Service.CustomServices
{
    public class UserService : ICustomService<User>
    {
        private readonly IRepository<User> _userRepository;
        public UserService(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        public void Delete(User entity)
        {
            try
            {
                if (entity != null)
                {
                    _userRepository.Delete(entity);
                    _userRepository.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public User Get(int Id)
        {
            try
            {
                var obj = _userRepository.Get(Id);
                if (obj != null)
                {
                    return obj;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<User> GetAll()
        {
            try
            {
                var obj = _userRepository.GetAll();
                if (obj != null)
                {
                    return obj;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Insert(User entity)
        {
            try
            {
                if (entity != null)
                {
                    _userRepository.Insert(entity);
                    _userRepository.SaveChanges();
                }
            }
            catch (DbUpdateException ex)
            {
                var innerException = ex.InnerException;
                if (innerException is SqlException sqlException && (sqlException.Number == 2601 || sqlException.Number == 2627))
                {
                    throw new DuplicateEntryException("Username or Email already exists.", ex); // Custom exception
                }
                else
                {
                    throw;
                }
            }
        }


        public void Remove(User entity)
        {
            try
            {
                if (entity != null)
                {
                    _userRepository.Remove(entity);
                    _userRepository.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Update(User entity)
        {
            try
            {
                if (entity != null)
                {
                    _userRepository.Update(entity);
                    _userRepository.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
