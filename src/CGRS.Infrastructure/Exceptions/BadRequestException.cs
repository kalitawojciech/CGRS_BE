using System;
using System.Collections.Generic;

namespace CGRS.Domain.Exceptions
{
    public class BadRequestException : Exception
    {
        public BadRequestException(Dictionary<string, List<string>> errors)
        {
            this.Data.Add("errors", errors);
        }
    }
}
