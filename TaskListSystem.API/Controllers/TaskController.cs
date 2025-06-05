using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Task_List_System.DTOs;
using Task_List_System.Services;

namespace Task_List_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {

        private readonly TaskService _taskService;

        public TaskController(TaskService taskService)
        {
            _taskService = taskService;
        }

        [HttpGet]
        public IActionResult GetAllTasks ()
        {
            var response = _taskService.GetAllTasks();

            return Ok(response);
        }

        [HttpPost]
        [ProducesResponseType(typeof(TaskResponseDTO), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ErrorsMessagesDTO), StatusCodes.Status400BadRequest)]
        public IActionResult CreateTask([FromBody] TaskRequestDTO taskRequest)
        {
           
            var response = _taskService.CreateTask(taskRequest);

            return Created(string.Empty, response);
        }
        [HttpPut]
        [Route("{Id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ErrorsMessagesDTO), StatusCodes.Status404NotFound)]
        public IActionResult UpdateTask([FromRoute] Guid Id,[FromBody] TaskRequestDTO taskRequest)
        {
            _taskService.UpdateTask(Id, taskRequest);

            return NoContent();
        }

        [HttpDelete]
        [Route("{Id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ErrorsMessagesDTO), StatusCodes.Status404NotFound)]
        public IActionResult DeleteTask([FromRoute] Guid Id)
        {
            var response = _taskService.DeleteTask(Id);

            return NoContent();
        }
    }
}
