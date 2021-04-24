using System;

namespace CGRS.Application.Exceptions
{
    public class BadRequestException : Exception
    {
        public BadRequestException(string error)
        {
            this.Data.Add("error", error);
        }
    }
}
