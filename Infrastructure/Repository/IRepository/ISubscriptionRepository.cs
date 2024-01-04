using Domain.Entities;
using Infrastructure.DTO.SubscriptionDTO;
using Infrastructure.Repository.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.IRepository
{
    public interface ISubscriptionRepository : IRepository<Subscription>
    {
        public Task<List<GetAllSubscriptionsDTO>> GetAllSubscriptions(long userId);
    }
}
