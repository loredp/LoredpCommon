using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LCommon.Remoting
{
    public class SocketRemotingClient
    {
        private readonly byte[] TimeoutMessage = Encoding.UTF8.GetBytes("Remoting request timeout.");
        private readonly Dictionary<int, IResponseHandler> _responseHandlerDict;

    }
}
