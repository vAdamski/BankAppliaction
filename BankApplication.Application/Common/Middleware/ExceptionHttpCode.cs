using BankApplication.Domain.Exceptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BankApplication.Application.Common.Middleware
{
    public static class ExceptionHttpCode
    {
        public static HttpStatusCode GetHttpCodeFormException(Exception exception)
        {
            HttpStatusCode code = HttpStatusCode.InternalServerError;

            switch (exception)
            {
                case ValidationException _:
                case BadRequestException _:
                case Exception _:
                    code = HttpStatusCode.BadRequest;
                    break;
            }

            return code;
        }
    }
}
