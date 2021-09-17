using ContactWebsite.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactWebsite.Tools
{
    public static class SessionManager
    {
        public static User user { get; private set; }

        public static void SetUser(this ISession session, User value)
        {
            session.SetString("User", JsonConvert.SerializeObject(value));
            user = value;
        }

        public static User GetUser(this ISession session)
        {
            return JsonConvert.DeserializeObject<User>(session.GetString("User"));
        }

        public static void Disconnect(this ISession session)
        {
            session.Clear();
            user = null;
        }
    }
}
