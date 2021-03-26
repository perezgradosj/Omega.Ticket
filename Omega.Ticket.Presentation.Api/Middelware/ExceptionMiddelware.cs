using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace Omega.Ticket.Presentation.Api.Middelware
{
    public class ExceptionMiddelware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddelware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }catch(Exception ex)
            {
                HttpResponse response = context.Response;
                response.ContentType = "application/json";
                response.StatusCode = 500;

                string message = ex.InnerException == null ? ex.Message : ex.Message + " " + ex.InnerException.Message;

                var responseModel = new { Message = message };

                string result = JsonSerializer.Serialize(responseModel);

                await response.WriteAsync(result);
            }
        }
    }
}
