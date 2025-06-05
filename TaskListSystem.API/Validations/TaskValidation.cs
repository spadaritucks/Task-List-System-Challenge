using FluentValidation;
using Task_List_System.DTOs;
namespace Task_List_System.Validations
{
    public class TaskValidation : AbstractValidator<TaskRequestDTO>
    {
        public TaskValidation()
        {
            RuleFor(task => task.Title).NotEmpty().WithMessage("O nome não pode ser vazio");
            RuleFor(task => task.Description).NotEmpty().WithMessage("A descrição não pode ser vazia");
            RuleFor(task => task.DueDate).NotEmpty().WithMessage("A data de vencimento não pode ser vazia");
            RuleFor(task => task.Status)
           .NotEmpty().WithMessage("O status não pode ser vazio")
           .IsInEnum().WithMessage("Status inválido. Use Pendente, EmProgresso ou Concluida.");
        }
    }
}
