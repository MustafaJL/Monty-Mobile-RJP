using Domain.Entities;
using Infrastructure.Data;
using Infrastructure.Repository.Base;
using Infrastructure.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<User> GetUserByUsername(string userName)
        {
            var user = await _context.Users.SingleOrDefaultAsync(x => x.Username.Equals(userName));
            if (user != null)
            {
                return user;
            }
            else return new User();
        }
    }
}
