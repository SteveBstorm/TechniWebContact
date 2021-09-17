using DAL.Entities;
using System.Collections.Generic;

namespace DAL.Interface
{
    public interface IUserService
    {
        IEnumerable<User> GetAll(string token);
        User Login(string email, string password);
        void Delete(int Id, string token);
    }
}