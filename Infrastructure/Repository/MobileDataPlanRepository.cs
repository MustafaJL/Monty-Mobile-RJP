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
    public class MobileDataPlanRepository : Repository<MobileDataPlan>, IMobileDataPlanRepository
    {
        public MobileDataPlanRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
