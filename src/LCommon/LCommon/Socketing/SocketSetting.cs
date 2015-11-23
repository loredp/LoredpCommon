using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LCommon.Socketing
{
    public class SocketSetting
    {
        public int SendBufferSize = 1024 * 16;//发送报文大小
        public int ReceiveBufferSize = 1024 * 16;//接收报文大小

        public int MaxSendPacketSize = 1024 * 64;//最大发送包大小
        public int SendMessageFlowControlThreshold = 1000;
        public int SendMessageFlowControlStepPercent = 1;
        public int SendMessageFlowControlWaitMilliseconds = 1;

        public int ReceiveDataBufferSize = 1024 * 16;
        public int ReceiveDataBufferPoolSize = 50;
    }
}
