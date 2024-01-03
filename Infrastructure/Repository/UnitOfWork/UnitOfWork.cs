using Infrastructure.Data;
using Infrastructure.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        public IUserRepository UserRepository { get; }
        public ISubscriptionRepository SubscriptionRepository { get; }
        public IMobileDataPlanRepository MobileDataPlanRepository { get; }

        private readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext dbContext, IUserRepository UserRepository,
            ISubscriptionRepository SubscriptionRepository,
            IMobileDataPlanRepository MobileDataPlanRepository
            )
        {
            _context = dbContext;
            this.UserRepository = UserRepository;
            this.SubscriptionRepository = SubscriptionRepository;
            this.MobileDataPlanRepository = MobileDataPlanRepository;
        }

        public int Save()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
