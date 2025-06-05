﻿using System.Net;

namespace Task_List_System.Exceptions
{
    public class ErrorOnValidationException : TaskListSystemException
    {
        private readonly List<string> _errors;
        public ErrorOnValidationException(List<string> errorMessages) : base(string.Empty)
        {
            _errors = errorMessages;
        }

        public override List<string> GetErrors() => _errors;
        public override HttpStatusCode GetHttpStatusCode() => HttpStatusCode.BadRequest;

    }
}
