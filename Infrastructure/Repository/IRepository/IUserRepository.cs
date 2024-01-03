using Domain.Entities;
using Infrastructure.Repository.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.IRepository
{
    public interface IUserRepository : IRepository<User>
    {
        public Task<User> GetUserByUsername(string userName);
    }
}
