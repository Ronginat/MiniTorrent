﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using DomainModel;
using MiniTorrent.Service.Domain;

namespace MiniTorrent.Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class MiniTorrentService : IMiniTorrentService
    {
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public User Login(string userName, string password)
        {
            AuthService authService = new AuthService();
            return authService.Login(userName, password);
        }
    }
}