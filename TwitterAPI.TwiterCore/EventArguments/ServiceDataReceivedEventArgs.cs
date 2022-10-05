using System;
using TwitterAPI.TwiterCore.Model;

namespace TwitterAPI.TwiterCore.EventArguments
{
    public class ServiceDataReceivedEventArgs : EventArgs
    {
        public SampleStreamModel? StreamDataResponse { get; set; }
    }
}
