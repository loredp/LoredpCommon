using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LCommon.Remoting
{
    public interface IRequestHandler
    {
        RemotingResponse HandleRequest(IRequestHandlerContext context, RemotingRequest remotingRequest);
    }
}
