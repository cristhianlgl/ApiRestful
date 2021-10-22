using ApiRestful.core.Excepciones;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ApiRestful.Infraestructura.Filters
{
    public class GlobalExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            var exception = (NegocioException)context.Exception;
            var validacion = new
            {
                status = 400,
                titulo = "Bad Request",
                Detalle = exception.Message
            };

            var json = new
            {
                errors = new[] { validacion }
            };

            context.Result = new BadRequestObjectResult(json);
            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            context.ExceptionHandled = true;
        }
    }
}
