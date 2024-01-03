using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Configuration
{
    public class MobileDataPlanConfiguration : IEntityTypeConfiguration<MobileDataPlan>
    {
        public void Configure(EntityTypeBuilder<MobileDataPlan> builder)
        {
            builder.HasData(new List<MobileDataPlan>
            {
                new MobileDataPlan()
                {
                    Id = 1,
                    Name = "Anghami",
                    Description = "2GB for anghami",
                    PricePerMonth = 10,
                },
                new MobileDataPlan()
                {
                    Id = 2,
                    Name = "Web & Talk",
                    Description = "60 min talking, 3Gb Mobile Data",
                    PricePerMonth = 20,
                },
                new MobileDataPlan()
                {
                    Id = 3,
                    Name = "Hs3",
                    Description = "6GB Mobile Data",
                    PricePerMonth = 30,
                }
            });
        }
    }
}
