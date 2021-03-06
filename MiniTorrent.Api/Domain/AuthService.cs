﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DomainModel;
using MiniTorrent.Dal.Providers;

namespace MiniTorrent.Api.Domain
{
    public class AuthService
    {
        private readonly MiniTorrentProvider _miniTorrentProvider;

        public AuthService()
        {
            _miniTorrentProvider = new MiniTorrentProvider();
        }

        public User Login(string userName, string password)
        {
            var user = _miniTorrentProvider.GetUser(userName);
            //var user = _userService.GetUser2(userName);
            if (user == null)
                return null;
            return ValidatePassword(password, user.Password) ? user : null;
        }

        private bool ValidatePassword(string password, string userPassword)
        {
            return password.Equals(userPassword);
        }
    }
}