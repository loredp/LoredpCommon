using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace LCommon.Socketing
{
    public interface ITcpConnection
    {
        bool IsConnected { get; }

        EndPoint LocalEndPoint { get; }

        EndPoint RemotingEndPoint { get; }

        void QueueMessage(byte[] message);

        void Close();
    }
}
