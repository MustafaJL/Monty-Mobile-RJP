﻿using Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class User : BaseEntity
    {
        [MaxLength(255)]
        public string FirstName { get; set; }
        [MaxLength(255)]
        public string? LastName { get; set; }
        [MaxLength(255)]
        public string Username { get; set; }
        [MaxLength(255)]
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Salt { get; set; }
        public string Password { get; set; }
    }
}
