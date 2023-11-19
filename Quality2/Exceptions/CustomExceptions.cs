using System.Collections.Generic;

namespace Quality2.Exceptions
{
    public class CustomException: Exception
    {
        //private readonly List<string> errors;

        public List<string> Errors { get; private set;}
        public CustomException(string message) : base(message)
        {
            Errors = new List<string>
            {
                message
            };
        }
        public CustomException(string message, IEnumerable<string> errors)
        : base(message) 
        {
            Errors = errors.ToList();
            
        }
    }

    public class BadRequestException: CustomException
    {
        
        public BadRequestException(string message, IEnumerable<string> errors)
        : base(message, errors) { }

        public BadRequestException(string message)
        : base(message) { }
    }

    public class NotFoundException : CustomException
    {
        public NotFoundException(string message)
        : base(message) { }
    }
}
