using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;

namespace IARATesteCotacao.Business.Shared
{
    public class ApiResult
    {
        public bool IsSuccess => !Errors.Any();
        public int ResultCode { get; set; } = StatusCodes.Status200OK;
        public IEnumerable<ValidationFailure> Errors { get; set; } = new List<ValidationFailure>();

        public ApiResult SetResultCode(int resultCode)
        {
            ResultCode = resultCode;
            return this;
        }
    }
    public class ApiResult<T> : ApiResult
    {
        public T Data { get; set; }

        public ApiResult SetData(T data)
        {
            Data = data;
            return this;
        }
    }
}
