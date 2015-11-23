using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace LCommon.Remoting.Exceptions
{
    public class RemotingRequestException : Exception
    {
        public RemotingRequestException(EndPoint serverEndPoint, RemotingRequest request, string errorMessage)
            : base(string.Format("Send request {0} to server [{1}] failed, errorMessage:{2}", request, serverEndPoint, errorMessage))
        {
        }

        public RemotingRequestException(EndPoint serverEndPoint, RemotingRequest request, Exception exception)
            : base(string.Format("Send request {0} to server [{1}] failed.", request, serverEndPoint), exception)
        {
        }
    }
}
