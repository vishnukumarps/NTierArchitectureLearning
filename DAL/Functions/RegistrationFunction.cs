using DAL.DataContext;
using DAL.InterFaces;
using Entities;
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
    }
}
