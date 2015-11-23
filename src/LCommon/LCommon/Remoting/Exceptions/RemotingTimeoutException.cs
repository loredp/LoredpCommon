using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace LCommon.Remoting.Exceptions
{
    public class RemotingTimeoutException : Exception
    {
        public RemotingTimeoutException(EndPoint serverEndPoint, RemotingRequest request, long timeoutMillis)
            : base(string.Format("Wait response from server[{0}] timeout, request:{1}, timeoutMillis:{2}ms", serverEndPoint, request, timeoutMillis))
        {
        }
    }
}
