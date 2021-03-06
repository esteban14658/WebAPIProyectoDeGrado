using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using PG.Bussiness.Exceptions;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using WebAPIProyectoDeGrado.Services;

namespace PG.Presentation.Middlewares
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception error)
            {
                var response = context.Response;
                response.ContentType = "application/json";

                switch (error)
                {
                    /*case NoContentException e:
                        response.StatusCode = (int)HttpStatusCode.NoContent;
                        break;*/
                    case CustomConflictException e:
                        response.StatusCode = (int)HttpStatusCode.Conflict;
                        break;
                    case AppException e:
                        // custom application error
                        response.StatusCode = (int)HttpStatusCode.BadRequest;
                        break;
                    case KeyNotFoundException e:
                        // not found error
                        response.StatusCode = (int)HttpStatusCode.NotFound;
                        break;
                    case DbUpdateException e:
                        response.StatusCode = (int)HttpStatusCode.BadRequest;
                        break;
                    default:
                        // unhandled error
                        response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        break;
                }

                var result = JsonSerializer.Serialize(new { message = error?.Message });
                await response.WriteAsync(result);
            }
        }
    }
}
