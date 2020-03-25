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
    public class RegistrationFunction : IRegistrationFunction
    {
        public async  Task<Registration> AddUser(Registration user)
        {
            using (var context = new DataBaseContext(DataBaseContext.ops.dbOptions))
            {
                user.InternalRegistrationId = Guid.NewGuid().ToString();
                await context.Registrations.AddAsync(user);
                await context.SaveChangesAsync();


            }
            return user;
        }



        public async Task<List<Registration>> GetAllUser()
        {

            using (var context = new DataBaseContext(DataBaseContext.ops.dbOptions))
            {
                var UserList = await context.Registrations.ToListAsync();


                return UserList;
            }
        }
    }
}
