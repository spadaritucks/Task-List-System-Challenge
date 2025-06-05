using Task_List_System.Enums;

namespace Task_List_System.Entities
{
    public class TaskEntity
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public DateTime DueDate { get; set; }

        public TaskStatusEnum Status { get; set; }
    }
}
