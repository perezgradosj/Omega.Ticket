using System;
using System.Collections.Generic;
using System.Text;

namespace Omega.Ticket.Core.Domain.DTO.Authentication
{
    public class VerifyTokenDTO
    {
        public int UserId { get; set; }
        public bool Error { get; set; }
        public string Message { get; set; }
    }
}
