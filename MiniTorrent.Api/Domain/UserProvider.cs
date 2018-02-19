﻿using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using MiniTorrent.Dal;
using User = DomainModel.User;

namespace MiniTorrent.Api.Domain
{
    public class UserProvider
    {
        public User GetUser(string userName)
        {
            var users = new List<User>
            {
                new User { UserName = "Barak", Password = "12345"},
                new User { UserName = "Noam", Password = "12345"},
                new User { UserName = "Nofar", Password = "12345"}
            };
            return users.FirstOrDefault(u => u.UserName.Equals(userName));
        }
        public User GetUser2(string userName)
        {
            using (var miniTorentDB = new MiniTorrentDBDataContext(ConfigurationManager.ConnectionStrings["MiniTorrentConnection"].ConnectionString))
            {
                return miniTorentDB.Users
                    .Where(u => u.UserName.Equals(userName))
                    .Select(u => new User { UserName = u.UserName, Password = u.Password })
                    .FirstOrDefault();
            }
        }
    }
}