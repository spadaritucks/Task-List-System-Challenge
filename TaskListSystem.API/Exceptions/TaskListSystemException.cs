using System.Net;

namespace Task_List_System.Exceptions
{
    public abstract class TaskListSystemException : SystemException
    {
        public TaskListSystemException(string errorMessage) : base(errorMessage)
        {
        }

        public abstract List<string> GetErrors();
        public abstract HttpStatusCode GetHttpStatusCode();
    }
}
