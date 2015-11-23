using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LCommon.Remoting
{
    public interface IResponseHandler
    {
        void HandleResponse(RemotingResponse remotingResponse);
    }
}
