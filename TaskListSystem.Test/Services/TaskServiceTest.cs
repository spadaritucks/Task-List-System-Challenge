using NUnit.Framework;
using Microsoft.EntityFrameworkCore;
using Task_List_System.Context;
using Task_List_System.Services;
using Task_List_System.DTOs;
using Task_List_System.Enums;
using Task_List_System.Exceptions;
using System;

namespace TaskListSystem.Test;

public class TaskServiceTest
{
    private TaskListSystemDbContext _context;
    private TaskService _service;

    [SetUp]
    public void Setup()
    {
        var options = new DbContextOptionsBuilder<TaskListSystemDbContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;
        _context = new TaskListSystemDbContext(options);
        _service = new TaskService(_context);
    }

    [TearDown]
    public void TearDown()
    {
        _context.Dispose();
    }

    [Test]
    public void CreateTask_DeveAdicionarTarefa()
    {
        var dto = new TaskRequestDTO
        {
            Title = "Teste",
            Description = "Descrição",
            DueDate = DateTime.Now.AddDays(1),
            Status = TaskStatusEnum.Concluida
        };

        var result = _service.CreateTask(dto);

        Assert.That(result.Title, Is.EqualTo("Teste"));
        Assert.That(_context.Tasks.CountAsync().Result, Is.EqualTo(1));
    }

    [Test]
    public void UpdateTask_TarefaNaoExiste_DeveLancarExcecao()
    {
        var dto = new TaskRequestDTO
        {
            Title = "Teste",
            Description = "Descrição",
            DueDate = DateTime.Now.AddDays(1),
            Status = TaskStatusEnum.Concluida
        };

        Assert.Throws<NotFoundException>(() => _service.UpdateTask(Guid.NewGuid(), dto));
    }

    [Test]
    public void DeleteTask_TarefaNaoExiste_DeveLancarExcecao()
    {
        Assert.Throws<NotFoundException>(() => _service.DeleteTask(Guid.NewGuid()));
    }
}
