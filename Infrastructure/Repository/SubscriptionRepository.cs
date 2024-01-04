using Domain.Entities;
using Infrastructure.Data;
using Infrastructure.DTO.SubscriptionDTO;
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
    public class SubscriptionRepository : Repository<Subscription>, ISubscriptionRepository
    {
        public SubscriptionRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<List<GetAllSubscriptionsDTO>> GetAllSubscriptions(long userId)
        {
            var subscriptions = await _context.Subscriptions
                                        .Include(x => x.MobileDataPlan)
                                        .Where(x => x.UserId == userId)
                                        .Select(x => new GetAllSubscriptionsDTO
                                        {
                                            Id = x.Id,
                                            MobileDataPlanName = x.MobileDataPlan.Name,
                                            StartDate = x.StartDate,
                                            EndDate = x.EndDate,
                                            Cost = x.Cost,
                                            LeftTime = TimeLeft(x.StartDate,x.EndDate),
                                            isActive = isActive(x.StartDate,x.EndDate)
                                        })
                                        .ToListAsync();
            return subscriptions;
        }

        private static TimeSpan TimeLeft(DateTime StartDate, DateTime EndDate)
        {
            DateTime currentDate = DateTime.UtcNow.AddHours(2);
            if (currentDate >= StartDate && currentDate <= EndDate)
            {
                return EndDate - currentDate;
            }
            else if (currentDate < StartDate)
            {
                return StartDate - currentDate;
            }
            else
            {
                return TimeSpan.Zero;
            }
        }
        public static bool isActive(DateTime StartDate, DateTime EndDate)
        {
            DateTime currentDate = DateTime.UtcNow.AddHours(2);

            if (currentDate >= StartDate && currentDate <= EndDate)
            {
                // Subscription is active
                return true;
            }
            else
            {
                // Subscription is not active
                return  false;
            }
        }
    }
}
