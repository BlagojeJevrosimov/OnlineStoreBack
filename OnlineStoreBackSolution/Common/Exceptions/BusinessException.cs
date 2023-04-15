using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Common.Exceptions
{
    public class BusinessException : Exception
    {
        public HttpStatusCode StatusCode { get; set; }


        public BusinessException(string Message, HttpStatusCode statusCode) : base(Message)
        {
            this.StatusCode = statusCode;
        }
    }
}
