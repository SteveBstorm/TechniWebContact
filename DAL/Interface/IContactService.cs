using DAL.Entities;
using System.Collections.Generic;

namespace DAL.Interface
{
    public interface IContactService
    {
        void Delete(int id);
        IEnumerable<Contact> GetAll();
        Contact GetById(int id);
        void Insert(Contact c);
        void Update(Contact c);
    }
}