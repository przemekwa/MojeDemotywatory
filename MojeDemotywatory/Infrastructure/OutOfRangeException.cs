using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MojeDemotywatory.Infrastructure
{
    public class OutOfRangeException : Exception
    {
        public OutOfRangeException(Exception e) : base("Brak strony", e)
        {
            
        }
    }
}