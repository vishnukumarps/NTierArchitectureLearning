﻿using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Microsoft.Extensions.Configuration;
namespace DAL.DataContext
{
    public  class AppConfiguration
    {
        public string  SqlConnectionString { get; set; }
        public AppConfiguration()
        {
            var configBuilder = new ConfigurationBuilder();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
            configBuilder.AddJsonFile(path, false);
            var root = configBuilder.Build();
            var appSettings = root.GetSection("ConnectionStrings:ConString");
            SqlConnectionString = appSettings.Value;
        }

    }
}
