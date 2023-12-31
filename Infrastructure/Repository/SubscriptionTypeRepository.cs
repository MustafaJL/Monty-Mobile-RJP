using Domain.Entities;
using Infrastructure.Data;
using Infrastructure.Repository.Base;
using Infrastructure.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class SubscriptionTypeRepository : Repository<SubscriptionType>, ISubscriptionTypeRepository
    {
        public SubscriptionTypeRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
