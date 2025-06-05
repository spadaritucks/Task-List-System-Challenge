using NUnit.Framework;
using Task_List_System.Validations;
using Task_List_System.DTOs;
using Task_List_System.Enums;
using System;

namespace TaskListSystem.Test.Validations;

public class TaskValidationTest
{
    [Test]
    public void Validate_EmptyTitle_MustReturnError()
    {
        var validator = new TaskValidation();
        var dto = new TaskRequestDTO
        {
            Title = "",
            Description = "desc",
            DueDate = DateTime.Now,
            Status = TaskStatusEnum.Pendente
        };
        var result = validator.Validate(dto);
        Assert.IsFalse(result.IsValid);
        Assert.That(result.Errors[0].ErrorMessage, Does.Contain("O nome não pode ser vazio"));
    }
}