using System;
using System.Collections.Generic;
using System.Text;

namespace IARATesteCotacao.Business.Shared
{
    public class ApiError
    {
        public string Title { get; }
        public string Message { get; }

        public ApiError(string title, string message)
        {
            Title = title;
            Message = message;
        }
    }
}
