using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using Task_List_System.Context;
using Task_List_System.DTOs;
using Task_List_System.Entities;
using Task_List_System.Exceptions;
using Task_List_System.Validations;

namespace Task_List_System.Services
{
    public interface ITaskService
    {
        List<TaskResponseDTO> GetAllTasks();
        TaskResponseDTO CreateTask(TaskRequestDTO taskRequest);
        TaskResponseDTO UpdateTask(Guid Id, TaskRequestDTO taskRequest);
        TaskResponseDTO DeleteTask(Guid Id);
    }
    public class TaskService : ITaskService
    {
        private readonly TaskListSystemDbContext context;

        public TaskService(TaskListSystemDbContext _context)
        {
            context = _context;
        }

        public List<TaskResponseDTO> GetAllTasks()
        {
            var tasks = context.Tasks.ToList();
            return tasks.Select(task => new TaskResponseDTO
            {
                Id = task.Id,
                Title = task.Title,
                Description = task.Description,
                DueDate = task.DueDate,
                Status = task.Status

            }).ToList();
      
        }

        public TaskResponseDTO CreateTask (TaskRequestDTO taskRequest)
        {
            Validate(taskRequest);

            var entity = new TaskEntity
            {
                
                Title = taskRequest.Title,
                Description = taskRequest.Description,
                DueDate = taskRequest.DueDate,
                Status = taskRequest.Status,
                Id = Guid.NewGuid()
            };
            context.Add(entity);
            context.SaveChanges();

            return new TaskResponseDTO
            {
                Id = entity.Id,
                Title = entity.Title,
                Description = entity.Description,
                DueDate = entity.DueDate,
                Status = entity.Status
            };



        }

        public TaskResponseDTO UpdateTask(Guid Id, TaskRequestDTO taskRequest)
        {
            Validate(taskRequest);
            
            var entity = context.Tasks.FirstOrDefault(task => task.Id == Id) ?? throw new NotFoundException("Tarefa não encontrada");
            entity.Title = taskRequest.Title;
            entity.Description = taskRequest.Description;
            entity.DueDate = taskRequest.DueDate;
            entity.Status = taskRequest.Status;

            context.Update(entity);
            context.SaveChanges();

            return new TaskResponseDTO
            {
                Id = entity.Id,
                Title = entity.Title,
                Description = entity.Description,
                DueDate = entity.DueDate,
                Status = entity.Status
            };

        }

        public TaskResponseDTO DeleteTask(Guid Id)
        {

            var entity = context.Tasks.FirstOrDefault(task => task.Id == Id) ?? throw new NotFoundException("Tarefa não encontrada");
            context.Remove(entity);
            context.SaveChanges();

            return new TaskResponseDTO
            {
                Id = entity.Id,
                Title = entity.Title,
                Description = entity.Description,
                DueDate = entity.DueDate,
                Status = entity.Status
            };
        }

        private void Validate(TaskRequestDTO request)
        {
            var validator = new TaskValidation();
            var result = validator.Validate(request);

            if (result.IsValid == false)
            {
                var errors = result.Errors.Select(failure => failure.ErrorMessage).ToList();
                throw new ErrorOnValidationException(errors);
            }
        }
    }
}
