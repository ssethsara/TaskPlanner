using System;
using System.Collections.Generic;
using System.Text;

namespace TaskPlanner
{
    public interface ITaskPlanner
    {

         void SetWorkdayStartAndStop(TimeSpan startTime, TimeSpan stopTime);
         void SetHoliday(DateTime date);
         void SetRecurringHoliday(DateTime dateTime);
         DateTime GetTaskFinishingDate(DateTime startDate, double days);
     
    }
}
