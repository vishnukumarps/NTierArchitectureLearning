using DAL.DataContext;
using DAL.InterFaces;
using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Functions
{
    public class UserFunction : IUserFunction
    {
        public async  Task<User> AddUser(User user)
        {
            using (var context = new DataBaseContext(DataBaseContext.ops.dbOptions))
            {
                user.InternalUserId = Guid.NewGuid().ToString();
                await context.Users.AddAsync(user);
                await context.SaveChangesAsync();


            }
            return user;
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
