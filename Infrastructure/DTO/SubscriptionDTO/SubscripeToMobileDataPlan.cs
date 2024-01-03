using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DTO.SubscriptionDTO
{
    public class SubscripeToMobileDataPlan
    {
        public long mobileDataPlanId {  get; set; }
        public int numberOfMonths { get; set; }
    }
}
