using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager.Core.Exceptions
{
    public class DomainException : Exception
    {
        internal List<string> _errors;
        public IReadOnlyCollection<string> Errors => _errors;  
        public DomainException() { }
        public DomainException(string message, List<string> errors) : base(message) 
        {
            _errors = errors;
        }
        public DomainException(string message) : base(message)
        { }
        public DomainException(string message, Exception innerException) : base(message)
        { }
    }
}
