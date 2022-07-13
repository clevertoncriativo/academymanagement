using System.Collections.Generic;
using System.Linq;

namespace academymanagement.Domain.Messages.Responses
{
    public class ResponseMessage<T>
    {
        public ResponseMessage()
        {
            Succeeded = false;
        }
        public ResponseMessage(T data)
        {
            Succeeded = true;
            Message = string.Empty;
            Errors = null;
            Data = data;
        }
        public T Data { get; set; }
        public bool Succeeded { get; set; }
        public IEnumerable<ResponseError> Errors { get; set; }
        public string Message { get; set; }
    }

    public class ResponseError
    {
        public string Key { get; set; }
        public string Value { get; set; }

        public ResponseError()
        {

        }
        public ResponseError(string key, string value)
        {
            this.Key = key;
            this.Value = value;
        }
    }
}
