using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Task_List_System.DTOs;
using Task_List_System.Exceptions;

namespace Task_List_System.Filters
{
    public class ExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            if (context.Exception is TaskListSystemException taskListSystemException)
            {
                context.HttpContext.Response.StatusCode = (int)taskListSystemException.GetHttpStatusCode();
                context.Result = new ObjectResult(new ErrorsMessagesDTO(taskListSystemException.GetErrors()));
            }
            else
            {
                ThrowUnkownError(context);
            }
        }

        private void ThrowUnkownError(ExceptionContext context)
        {
            context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
            context.Result = new ObjectResult(new ErrorsMessagesDTO("Erro Desconhecido"));
        }
    }
}
