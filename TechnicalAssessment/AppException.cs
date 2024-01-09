using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnicalAssessment
{
    internal class AppException : Exception
    {

        public override string Message { get; } = string.Empty;



        public AppException()
        {
        }

        public AppException(string message) : base(message)
        {
            Message = message;
        }

        public AppException(string message, Exception innerException) : base(message, innerException)
        {
            Message = message;

        }

    }
}
