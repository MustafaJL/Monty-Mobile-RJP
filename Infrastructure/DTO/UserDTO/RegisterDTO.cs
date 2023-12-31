using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DTO.UserDTO
{
    public class RegisterDTO
    {
        [MaxLength(255), Required]
        public string FirstName { get; set; }
        [MaxLength(255)]
        public string? LastName { get; set; }
        [MaxLength(255)]
        public string Username { get; set; }
        [MaxLength(255)]
        public string Email { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
    }
}
