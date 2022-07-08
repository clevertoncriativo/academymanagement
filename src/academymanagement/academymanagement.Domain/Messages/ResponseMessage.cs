using System;
using System.Collections.Generic;
using System.Text;

namespace academymanagement.Domain.Messages
{
    public class ResponseMessage<T>
    {
        public T Model { get; private set; }
        public bool Succeeded { get; private set; } = true;
        public ICollection<KeyValuePair<string, string>> Errors { get; private set; } = new List<KeyValuePair<string, string>>();

        protected ResponseMessage()
        {

        }

        protected ResponseMessage(T model)
            : base()
        {
            this.Model = model;
        }

        public static ResponseMessage<T> FromResult(T model)
        {
            return new ResponseMessage<T>(model);
        }

        public static ResponseMessage<T> FromInvalidResult(ICollection<KeyValuePair<string, string>> errors)
        {
            return new ResponseMessage<T>
            {
                Errors = errors,
                Succeeded = false
            };
        }
    }
}
