using DAL.DataContext;
using DAL.Interfaces;
using Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Services
{
    public class UserDataService : IUserDataService
    {
        public async  Task<User> AddUser(User newUser)
        {
            using (var context = new DataBaseContext(DataBaseContext.ops.dbOptions))
            {
                newUser.InternalUserId = Guid.NewGuid().ToString();
                await context.Users.AddAsync(newUser);
                await context.SaveChangesAsync();


            }
            return newUser;
        }



        public async Task<List<User>> GetAllUser()
        {

            using (var context = new DataBaseContext(DataBaseContext.ops.dbOptions))
            {
                var UserList = await context.Users.ToListAsync();


                return UserList;
            }
        }
    }
}
