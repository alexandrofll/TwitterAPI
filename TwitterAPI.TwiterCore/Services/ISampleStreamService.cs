using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitterAPI.TwiterCore.Services
{
    public interface ISampleStreamService
    {
        event EventHandler? DataReceivedEvent;
        Task StartStreamAsync(string requestUri, int maxTweets, int maxConnectionAttempts);
    }
}
