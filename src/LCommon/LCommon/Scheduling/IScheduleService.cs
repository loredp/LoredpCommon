using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LCommon.Scheduling
{
    public interface IScheduleService
    {
        void StartTask(string name, Action action, int dueTime, int period);

        void StopTask(string name);
    }
}
