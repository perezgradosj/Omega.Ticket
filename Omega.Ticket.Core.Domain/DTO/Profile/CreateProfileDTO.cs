using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Omega.Ticket.Core.Domain.DTO.Profile
{
    public class CreateProfileDTO
    {
        [Required]
        public string Name { get; set; }
    }
}
