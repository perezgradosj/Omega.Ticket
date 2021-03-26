using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Omega.Ticket.Core.Domain.DTO.User
{
    public class CreateUserDTO
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [RegularExpression("^[a-z0-9_\\+-]+(\\.[a-z0-9_\\+-]+)*@[a-z0-9-]+(\\.[a-z0-9]+)*\\.([a-z]{2,4})$", ErrorMessage = "Invalid email format.")]
        public string Email { get; set; }
        [Required]        
        public string PasswordDecrypted { get; set; }
        [Required]
        [RegularExpression(@"^(?!0+$)(\+\d{1,3}[- ]?)?(?!0+$)\d{7,15}$", ErrorMessage = "Please enter valid phone no.")]
        public string Phone { get; set; }
        public string Photo { get; set; }
        [Required]
        public int ProfileId { get; set; }
    }
}
