using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Sdt.Practice
{
    /// <summary>
    /// API 的未捕捉异常处理
    /// </summary>
    public class ApiExceptionFilter : IExceptionFilter
    {
        /// <summary>
        /// 仅针对 /api/ 开头的 HTTP API 处理异常
        /// </summary>
        /// <param name="context">异常的上下文</param>
        public void OnException(ExceptionContext context)
        {
            var route = context.ActionDescriptor.AttributeRouteInfo.Template;
            if (route.StartsWith("api/"))
            {
                HandleException(context);
            }
        }

        /// <summary>
        /// 针对不同的异常，HTTP Response 使用不同的 Status Code， Body 均定义为 { "message": "exception message" }
        /// </summary>
        /// <param name="context"></param>
        private void HandleException(ExceptionContext context)
        {
            context.HttpContext.Response.StatusCode = GetStatusCode(context);

            if (context.Exception is ValidationException exception)
            {
                context.Result = new ObjectResult(
                    new
                    {
                        Message = exception.Message
                    }
                );
            }
            else
                context.Result = new ObjectResult(
                    new
                    {
                        context.Exception.Message
                    }
                );

            context.ExceptionHandled = true;
        }

        private int GetStatusCode(ExceptionContext context)
        {

            if (context.Exception is ValidationException)
            {
                return StatusCodes.Status400BadRequest;
            }

            //if (context.Exception is EntityNotFoundException)
            //{
            //    return StatusCodes.Status404NotFound;
            //}

            return StatusCodes.Status500InternalServerError;
        }
    }
}
