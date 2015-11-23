using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LCommon.Socketing;

namespace LCommon.Remoting
{
    public interface IRequestHandlerContext
    {
        ITcpConnection Connection { get; }

        Action<RemotingResponse> SendRemotingResponse { get; }
    }
}
