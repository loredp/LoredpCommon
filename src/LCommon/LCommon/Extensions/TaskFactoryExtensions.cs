using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LCommon.Extensions
{
    public static class TaskFactoryExtensions
    {
        public static Task StartDelayedTask(this TaskFactory factory, int millisecondsDelay, Action action)
        {
            return new Task(() => { }, factory.CancellationToken);
        }
    }
}
