using Moq;
using NUnit.Framework;
using Task_List_System.Controllers;
using Task_List_System.Services;
using Task_List_System.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace TaskListSystem.Test.Controllers;

[TestFixture]
public class TaskControllerTest
{
    private Mock<ITaskService> _serviceMock;
    private TaskController _controller;

    [SetUp]
    public void Setup()
    {
        _serviceMock = new Mock<ITaskService>();
        _controller = new TaskController(_serviceMock.Object);
    }

    [Test]
    public void GetAllTasks_DeveRetornarOk()
    {
        // Arrange
        _serviceMock.Setup(s => s.GetAllTasks()).Returns(new List<TaskResponseDTO>());

        // Act
        var result = _controller.GetAllTasks();

        // Assert
        Assert.IsInstanceOf<OkObjectResult>(result);
    }

    [Test]
    public void CreateTask_DeveRetornarCreated()
    {
        // Arrange
        var dto = new TaskRequestDTO();
        _serviceMock.Setup(s => s.CreateTask(dto)).Returns(new TaskResponseDTO());

        // Act
        var result = _controller.CreateTask(dto);

        // Assert
        Assert.IsInstanceOf<CreatedResult>(result);
    }
}
