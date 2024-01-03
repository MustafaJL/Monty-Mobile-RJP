using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasIndex(x => x.Username).IsUnique();
            builder.HasData(new User
            {
               Id = 1,
               FirstName = "admin",
               LastName = "admin",
               Email = "admin@monty.com",
               Username = "admin",
               PhoneNumber = "01000000",
               Salt = "Vkv4EVK21YeHqJ2xumfXsKMdOe2o0smoG4g+5Q+xKT55CHU8Gm6f2msoT+B7XdfzTUPFx3cIVa4PlOMq+iQrv+6kHRhuvWdwIv/31YtOgY2bfshFskuFzklqBiaygshnUb7NrwwwdhJcaGLcMHQ7L9RW7cKjgAbHABRUWxsm4eU=",
               Password = "mgjLOOyDs6fRsf94geNGIvSNk/ugZ+XstJZ0qqyMR3KG7xfEv2rd865kgsk4GqoJCCoTP7GFmBJICvJn1DaiDA==",
               isAdmin = true,             
            });
        }
    }
}
