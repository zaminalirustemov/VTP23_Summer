using Participant_Panel.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Participant_Panel.Common.ResponseObjects
{
    public class Response : IResponse
    {
        public Response(ResponseType responseType)
        {
            ResponseType = responseType;
        }
        public Response(string message, ResponseType responseType)
        {
            Message = message;
            ResponseType = responseType;
        }
        public string Message { get; set; }
        public ResponseType ResponseType { get; set; }

    }
}
