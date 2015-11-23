using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;

namespace LCommon.Socketing
{
    public interface IConnectionEventListener
    {
        void OnConnectionAccepted(ITcpConnection connection);

        void OnConnectionEstablished(ITcpConnection connection);

        void OnConnectionFailed(SocketError socketError);

        void OnConnectionClosed(ITcpConnection connection, SocketError socketError);
    }
}
