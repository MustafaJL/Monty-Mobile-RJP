using Infrastructure.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository UserRepository { get; }
        ISubscriptionRepository SubscriptionRepository { get; }
        ISubscriptionTypeRepository SubscriptionTypeRepository { get; }
        IMobileDataPlanRepository MobileDataPlanRepository { get; }
        int Save();
    }
}
