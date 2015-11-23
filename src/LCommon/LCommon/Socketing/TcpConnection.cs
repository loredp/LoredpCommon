using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace LCommon.Socketing
{
    public class TcpConnection : ITcpConnection
    {
        #region Private Variables

        private readonly Socket _socket;
        private readonly SocketSetting _setting;
        private readonly EndPoint _localEndPoint;
        private readonly EndPoint _remotingEndPoint;
        private readonly SocketAsyncEventArgs _receiveSocketArgs;


        #endregion

        #region ITcpConnection 成员

        public bool IsConnected
        {
            get { throw new NotImplementedException(); }
        }

        public EndPoint LocalEndPoint
        {
            get { throw new NotImplementedException(); }
        }

        public EndPoint RemotingEndPoint
        {
            get { throw new NotImplementedException(); }
        }

        public void QueueMessage(byte[] message)
        {
            throw new NotImplementedException();
        }

        public void Close()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region ITcpConnection 成员

        bool ITcpConnection.IsConnected
        {
            get { throw new NotImplementedException(); }
        }

        EndPoint ITcpConnection.LocalEndPoint
        {
            get { throw new NotImplementedException(); }
        }

        EndPoint ITcpConnection.RemotingEndPoint
        {
            get { throw new NotImplementedException(); }
        }

        void ITcpConnection.QueueMessage(byte[] message)
        {
            throw new NotImplementedException();
        }

        void ITcpConnection.Close()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
