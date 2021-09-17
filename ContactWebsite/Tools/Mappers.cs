using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DA = DAL.Entities;
using WEB = ContactWebsite.Models;

namespace ContactWebsite.Tools
{
    public static class Mappers
    {
        public static WEB.Contact ToWeb(this DA.Contact contact)
        {
            return new WEB.Contact
            {
                Id = contact.Id,
                FirstName = contact.FirstName,
                LastName = contact.LastName,
                Email = contact.Email
            };
        }

        public static DA.Contact ToDAL(this WEB.Contact contact)
        {
            return new DA.Contact
            {
                Id = contact.Id,
                FirstName = contact.FirstName,
                LastName = contact.LastName,
                Email = contact.Email
            };
        }

        public static WEB.User ToWEB(this DA.User u)
        {
            return new WEB.User
            {
                Id = u.Id,
                Email = u.Email,
                IsAdmin = u.IsAdmin,
                Token = u.Token
            };
        }

        public static DA.User ToDAL(this WEB.User u)
        {
            return new DA.User
            {
                Id = u.Id,
                Email = u.Email,
                IsAdmin = u.IsAdmin,
                Token = u.Token
            };
        }


    }
}
