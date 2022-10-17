﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebCoreAPI.Config
{
    public class MongoDBSettings
    {
        public string Host { get; set; }
        public string Port { get; set; }
        public string User { get; set; }
        public string Password { get; set; }
        public string ConnectionString { 
            get 
            {
                return $"mongodb://{User}:{Password}@{Host}:{Port}";
            } 
        }

    }
}
