using Participant_Panel.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Participant_Panel.Common.ResponseObjects
{
    public class Response<T> : Response, IResponse<T>
    {
        public Response(ResponseType responseType, T data) : base(responseType)
        {
            Data = data;
        }

        public Response(ResponseType responseType, string message) : base(message, responseType)
        {
        }

        public Response(ResponseType responseType, T data, List<CustomValidationError> errors) : base(responseType)
        {
            ValidationErrors = errors;
            Data = data;
        }
        public T Data { get; set; }
        public List<CustomValidationError> ValidationErrors { get; set; }
    }
}
