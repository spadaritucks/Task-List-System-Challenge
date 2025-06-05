using System.Net;

namespace Task_List_System.Exceptions
{
    public class NotFoundException : TaskListSystemException
    {
         public NotFoundException(string errorMessage) : base(errorMessage)
        {
        }
        public override List<string> GetErrors() => new List<string> { Message };
        public override HttpStatusCode GetHttpStatusCode() => HttpStatusCode.NotFound;
    }
}
