using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitterAPI.Application.Exceptions
{
    /// <summary>
    /// Custom defined exception for tweets not found
    /// </summary>
    public class TweetNotFoundException : Exception
    {
        public TweetNotFoundException()
            : base()
        {

        }

        public TweetNotFoundException(string message)
            : base(message)
        {

        }

        public TweetNotFoundException(string message, Exception inner)
            : base(message, inner)
        {

        }
    }
}
