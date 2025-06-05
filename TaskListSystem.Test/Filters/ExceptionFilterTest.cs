using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Http;
using Moq;
using NUnit.Framework;
using Task_List_System.Filters;
using Task_List_System.Exceptions;
using Task_List_System.DTOs;
using System.Net;

namespace TaskListSystem.Test.Filters;

public class ExceptionFilterTest
{
    [Test]
    public void OnException_DeveRetornarErroCustomizado()
    {
        var exception = new NotFoundException("Não encontrado");
        var context = new ExceptionContext(
            new ActionContext
            {
                HttpContext = new DefaultHttpContext()
            },
            new List<IFilterMetadata>()
        )
        {
            Exception = exception
        };

        var filter = new ExceptionFilter();
        filter.OnException(context);

        Assert.That(context.HttpContext.Response.StatusCode, Is.EqualTo((int)HttpStatusCode.NotFound));
        Assert.IsInstanceOf<ObjectResult>(context.Result);
        var result = context.Result as ObjectResult;
        Assert.IsInstanceOf<ErrorsMessagesDTO>(result.Value);
    }

    [Test]
    public void OnException_DeveRetornarErroDesconhecido()
    {
        var exception = new Exception("Erro desconhecido");
        var context = new ExceptionContext(
            new ActionContext
            {
                HttpContext = new DefaultHttpContext()
            },
            new List<IFilterMetadata>()
        )
        {
            Exception = exception
        };

        var filter = new ExceptionFilter();
        filter.OnException(context);

        Assert.That(context.HttpContext.Response.StatusCode, Is.EqualTo(StatusCodes.Status500InternalServerError));
        Assert.IsInstanceOf<ObjectResult>(context.Result);
        var result = context.Result as ObjectResult;
        Assert.IsInstanceOf<ErrorsMessagesDTO>(result.Value);
    }
}
