using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DTO.SubscriptionDTO
{
    public class GetAllSubscriptionsDTO
    {
        public long Id { get; set; }
        public string MobileDataPlanName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal Cost { get; set; }
        public TimeSpan LeftTime { get; set; }
        public bool isActive { get; set; }
    }
}
