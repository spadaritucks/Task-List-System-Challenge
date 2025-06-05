namespace Task_List_System.DTOs
{
    public class ErrorsMessagesDTO
    {
        public List<string> Errors { get; private set; }

        public ErrorsMessagesDTO(string message)
        {
            Errors = [message];
        }

        public ErrorsMessagesDTO(List<string> messages)
        {
            Errors = messages;
        }
    }
}
