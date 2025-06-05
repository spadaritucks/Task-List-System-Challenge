using NUnit.Framework;
using Moq;
using Task_List_System.Controllers;
using Task_List_System.Services;
using Task_List_System.DTOs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace TaskListSystem.Test.Controllers;

public class TaskControllerTest
{
    private Mock<TaskService> _serviceMock;
    private TaskController _controller;

    [SetUp]
    public void Setup()
    {
        _serviceMock = new Mock<TaskService>(null);
        _controller = new TaskController(_serviceMock.Object);
    }

    [Test]
    public void GetAllTasks_DeveRetornarOk()
    {
        _serviceMock.Setup(s => s.GetAllTasks()).Returns(new List<TaskResponseDTO>());
        var result = _controller.GetAllTasks();
        Assert.IsInstanceOf<OkObjectResult>(result);
    }

    [Test]
    public void CreateTask_DeveRetornarCreated()
    {
        var dto = new TaskRequestDTO();
        _serviceMock.Setup(s => s.CreateTask(dto)).Returns(new TaskResponseDTO());
        var result = _controller.CreateTask(dto);
        Assert.IsInstanceOf<CreatedResult>(result);
    }
}