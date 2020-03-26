using BLL.Interfaces;
using BLL.Services;
using DAL.Services;
using DAL.Interfaces;
using EncryptionLayer.Interfaces;
using EncryptionLayer.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.DependencyManagement
{
    public static class DependencyRegistrar
    {
        public static IServiceCollection AddBusiness(this IServiceCollection services)
        {

          
            services.AddSingleton<IUserBusinessService, UserBusinessService>();
            services.AddTransient<IUserBusinessService, UserBusinessService>();

            services.AddSingleton<IEnciphermentUtilService, EnciphermentUtilService>();
            services.AddTransient<IEnciphermentUtilService, EnciphermentUtilService>();
          
            services.AddSingleton<IUserDataService, UserDataService>();
            services.AddTransient<IUserDataService, UserDataService>();



            services.AddSingleton<IUserEncryptionService, UserEncryptionService>();
            services.AddTransient<IUserEncryptionService, UserEncryptionService>();



            return services;
        }

    }


}
