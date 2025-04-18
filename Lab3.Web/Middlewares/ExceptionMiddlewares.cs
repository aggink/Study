﻿using CoreLib.Common.Extensions;
using Lab3.Web.Middlewares.DtoModels;
using System.Net;

namespace Lab3.Web.Middlewares
{
    public sealed class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;

        public ExceptionMiddleware(
            RequestDelegate next,
            ILogger<ExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                var error = GetErrorResponse(context, ex);

                context.Response.StatusCode = (int)error.StatusCode;
                await context.Response.WriteAsJsonAsync(error.Response);
            }
        }

        private (ErrorResponseDto Response, HttpStatusCode StatusCode) GetErrorResponse(HttpContext content, Exception ex)
        {
            switch (ex)
            {
                case BusinessLogicException businessException:
                    return (new ErrorResponseDto
                    {
                        Code = businessException.HResult.ToString(),
                        Message = businessException.Message
                    }, HttpStatusCode.BadRequest);
                default:
                    _logger.LogError(ex, "Произошла ошибка при выполнении запроса. Описание запроса: {Request}", content.Request);

                    return (new ErrorResponseDto
                    {
                        Code = ex.HResult.ToString(),
                        Message = "Что-то пошло не так..."
                    }, HttpStatusCode.InternalServerError);
            }
        }
    }
}
