using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitterAPI.Application.Options
{
    public class ConnectionStringOptions
    {
        public const string Position = "ConnectionStringOptions";

        public string TweetDbConnectionString { get; set; }
    }
}
