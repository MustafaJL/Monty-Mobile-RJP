using Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Subscription : BaseEntity
    {
        public long UsertId { get; set; }
        public User User { get; set; }
        public long MobileDataPlanId { get; set; }
        public MobileDataPlan MobileDataPlan { get; set; }
        public long SubscriptionTypeId { get; set; }
        public SubscriptionType SubscriptionType { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
