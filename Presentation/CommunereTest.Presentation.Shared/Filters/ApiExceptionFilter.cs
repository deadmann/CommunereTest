using System;
using System.Collections.Generic;
using CommunereTest.Application.Common.Exceptions;
using CommunereTest.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CommunereTest.Presentation.Shared.Filters
{
    public sealed class ApiExceptionFilter : ExceptionFilterAttribute
    {
        private readonly IDictionary<Type, Action<ExceptionContext>> _exceptionHandlers;

        public ApiExceptionFilter()
        {
            // Register known exception types and handlers.
            _exceptionHandlers = new Dictionary<Type, Action<ExceptionContext>>
            {
                { typeof(ValidationException), HandleValidationException },
                { typeof(AppException), HandleAppException },
                { typeof(UnauthorizedAccessException), HandleUnauthorizedAccessException }
            };
        }

        public override void OnException(ExceptionContext context)
        {
            HandleException(context);
            base.OnException(context);
        }

        private void HandleException(ExceptionContext context)
        {
            Type type = context.Exception.GetType();
            if (_exceptionHandlers.ContainsKey(type))
            {
                _exceptionHandlers[type].Invoke(context);
                return;
            }

            HandleUnknownException(context);
        }

        private void HandleUnknownException(ExceptionContext context)
        {
            var details = new ErrorResponse
            {
                Title = "An error occurred while processing your request.",
            };

            context.Result = new ObjectResult(details)
            {
                StatusCode = StatusCodes.Status500InternalServerError
            };

            context.ExceptionHandled = true;
        }

        private void HandleValidationException(ExceptionContext context)
        {
            var exception = context.Exception as ValidationException;

            var details = new ErrorResponse()
            {
                Title = exception.Message,
                Errors = exception.Failures
            };

            context.Result = new BadRequestObjectResult(details);
            context.ExceptionHandled = true;
        }

        private void HandleAppException(ExceptionContext context)
        {
            var exception = context.Exception as AppException;

            var details = new ErrorResponse()
            {
                Title = exception.Message,
                Errors = exception.Failures
            };

            context.Result = new BadRequestObjectResult(details);
            context.ExceptionHandled = true;
        }

        private void HandleUnauthorizedAccessException(ExceptionContext context)
        {
            var exception = context.Exception as UnauthorizedAccessException;

            var details = new ErrorResponse()
            {
                Title = exception.Message
            };

            context.Result = new UnauthorizedObjectResult(details);
            context.ExceptionHandled = true;
        }
    }
}
