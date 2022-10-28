using BankApplication.Application.Common.Middleware;
using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApplication.Application
{
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseMiddlewareApplication(this IApplicationBuilder builder)
        {
            builder.UseMiddleware<ExceptionHandlerMiddleware>();

            return builder;
        }
    }
}
